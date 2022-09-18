using Leopotam.EcsLite;
using UnityEngine;

public class ECSController : MonoBehaviour
{
    EcsWorld _world;
    IEcsSystems _systems;
    [SerializeField] private Config _configuration = null;

    public EcsWorld Init()
    {
        _world = new EcsWorld();

        _systems = new EcsSystems(_world, _configuration);
        _systems.Add(new TriggerActivationSystem());
        _systems.Add(new TriggerMoveResponceSystem());
        _systems.Add(new XZClickFollowSystem());
        _systems.Add(new RotateTowardsXZVelocitySystem());
        _systems.Init();

        return _world;
    }

    void Update()
    {
        _systems?.Run();
    }

    void OnDestroy()
    {
        if (_systems != null)
        {
            _systems.Destroy();
            _systems = null;
        }
        if (_world != null)
        {
            _world.Destroy();
            _world = null;
        }
    }
}
