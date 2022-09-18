using Leopotam.EcsLite;
using UnityEngine;

public class RotateTowardsXZVelocitySystem : IEcsRunSystem, IEcsInitSystem
{
    private Config _config;
    private EcsWorld _world;

    private EcsFilter _rotatorEntities;
    private EcsPool<RotatorTowardsXZVelocity> _rotatorPool;

    public void Init(IEcsSystems systems)
    {
        _config = systems.GetShared<Config>();
        _world = systems.GetWorld();

        _rotatorEntities = _world.Filter<RotatorTowardsXZVelocity>().End();
        _rotatorPool = _world.GetPool<RotatorTowardsXZVelocity>();
    }

    public void Run(IEcsSystems systems)
    {
        Quaternion argetRot = new Quaternion();
        float maxRotDegrees = Time.deltaTime * _config.RotationSpeed;

        foreach (var i in _rotatorEntities)
        {
            ref var _rotator = ref _rotatorPool.Get(i);

            if (_rotator.ChangeInPositionDetected)
            {
                argetRot.SetLookRotation(_rotator.CurFramePosition - _rotator.PrevFramePosition, Vector3.up);
                _rotator.Transform.localRotation = Quaternion.RotateTowards(_rotator.Transform.localRotation, argetRot, maxRotDegrees);
            }

            _rotator.PrevFramePosition = _rotator.CurFramePosition;
        }
    }
}
