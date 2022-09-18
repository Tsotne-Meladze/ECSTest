using Leopotam.EcsLite;
using UnityEngine;

public class TriggerMoveResponceSystem : IEcsRunSystem, IEcsInitSystem
{
    private Config _config;
    private EcsWorld _world;

    private EcsFilter _entitiesToMove;
    private EcsPool<TriggerMoveResponder> _movePool;
    private EcsPool<Trigger> _triggerPool;

    public void Init(IEcsSystems systems)
    {
        _config = systems.GetShared<Config>();
        _world = systems.GetWorld();

        _entitiesToMove = _world.Filter<TriggerMoveResponder>().End();
        _movePool = _world.GetPool<TriggerMoveResponder>();
        _triggerPool = _world.GetPool<Trigger>();
    }

    public void Run(IEcsSystems systems)
    {
        float maxDistanceDelta = Time.deltaTime * _config.GateMoveSpeed;

        foreach(var entity in _entitiesToMove)
        {
            ref var moveTarget = ref _movePool.Get(entity);
            ref var trigger = ref _triggerPool.Get(moveTarget.Trigger);

            moveTarget.Transform.localPosition = Vector3.MoveTowards
            (
                moveTarget.Transform.localPosition,
                trigger.IsActive ? moveTarget.ActivePosition : moveTarget.PassivePosition,
                maxDistanceDelta
            );
        }
    }
}