using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class PlayerAssembler : MonoBehaviour
{
    [Inject] private EcsWorld _world = null;
    [SerializeField] private Transform _player = null;

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

        var rotationPool = _world.GetPool<RotatorTowardsXZVelocity>();
        ref var rotatorComponent = ref rotationPool.Add(entity);
        rotatorComponent.Init(_player);
    }
}