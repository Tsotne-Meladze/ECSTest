using Leopotam.EcsLite;
using UnityEngine;

public class TriggerActivationSystem : IEcsRunSystem, IEcsInitSystem
{
    private Config _config;
    private EcsWorld _world;

    private EcsFilter _triggerEntities;
    private EcsFilter _activatorEntities;
    private EcsPool<Trigger> _triggerPool;
    private EcsPool<TriggerActivator> _activatorPool;

    public void Init(IEcsSystems systems)
    {
        _config = systems.GetShared<Config>();
        _world = systems.GetWorld();

        _triggerEntities = _world.Filter<Trigger>().End();
        _activatorEntities = _world.Filter<TriggerActivator>().End();
        _triggerPool = _world.GetPool<Trigger>();
        _activatorPool = _world.GetPool<TriggerActivator>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var i in _triggerEntities)
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                Debug.Log("Ka");
            }

            ref var trigger = ref _triggerPool.Get(i);

            trigger.IsActive = false;

            foreach (var j in _activatorEntities)
            {
                ref var triggerer = ref _activatorPool.Get(j);

                if (Vector3.Distance(triggerer.Transform.position, trigger.Transform.position) < _config.PadCollisionDistance)
                {
                    trigger.IsActive = true;
                    break;
                }
            }
        }
    }
}
