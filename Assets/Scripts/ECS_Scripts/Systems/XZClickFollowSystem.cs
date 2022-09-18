using Leopotam.EcsLite;
using UnityEngine;

public class XZClickFollowSystem : IEcsRunSystem, IEcsInitSystem
{
    private Config _config;
    private EcsWorld _world;

    private EcsFilter _followerEntities;
    private EcsPool<XZClickFollower> _followerPool;

    private Vector3 _targetPos;
    private bool _firstTargetPositionDetected;

    public void Init(IEcsSystems systems)
    {
        _config = systems.GetShared<Config>();
        _world = systems.GetWorld();

        _followerEntities = _world.Filter<XZClickFollower>().End();
        _followerPool = _world.GetPool<XZClickFollower>();
    }

    public void Run(IEcsSystems systems)
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitInfo, 100f) && hitInfo.collider.gameObject.tag == "Ground")
            {
                _targetPos = hitInfo.point;
                _targetPos.y = 0f;
                _firstTargetPositionDetected = true;
            }
        }

        if(_firstTargetPositionDetected)
        {
            float maxDistanceDelta = Time.deltaTime * _config.PlayerRunSpeed;

            foreach (var i in _followerEntities)
            {
                ref var _follower = ref _followerPool.Get(i);

                _follower.Transform.position = Vector3.MoveTowards(_follower.Transform.position, _targetPos, maxDistanceDelta);
            }
        }
    }
}
