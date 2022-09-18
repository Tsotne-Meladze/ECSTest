using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class PlayerAssembler : MonoBehaviour
{
    [Inject] private EcsWorld _world = null;
    [SerializeField] private Transform _player = null;
    [SerializeField] private Animator _animator = null;

    private void Start()
    {
        //Init Player
        int entity = _world.NewEntity();
        var activatorPool = _world.GetPool<TriggerActivator>();
        ref var activatorComponent = ref activatorPool.Add(entity);
        activatorComponent.Init(_player);

        var clickFollowPool = _world.GetPool<XZClickFollower>();
        ref var followComponent = ref clickFollowPool.Add(entity);
        followComponent.Init(_player);

        var cachedPosPool = _world.GetPool<CachedPosition>();
        ref var cachedPosComponent = ref cachedPosPool.Add(entity);
        cachedPosComponent.Init(_player);

        var posAnimPool = _world.GetPool<CachedPositionAnimator>();
        ref var posAnimComponent = ref posAnimPool.Add(entity);
        posAnimComponent.Init(_animator, Animator.StringToHash("IsRunning"), entity);
    }
}