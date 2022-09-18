using Leopotam.EcsLite;

public class ChachedPositionUpdateSystem : IEcsRunSystem, IEcsInitSystem
{
    private EcsWorld _world;

    private EcsFilter _entities;
    private EcsPool<CachedPosition> _pool;

    public void Init(IEcsSystems systems)
    {
        _world = systems.GetWorld();

        _entities = _world.Filter<CachedPosition>().End();
        _pool = _world.GetPool<CachedPosition>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var i in _entities)
        {
            ref var chachedPosition = ref _pool.Get(i);

            chachedPosition.PrevFramePosition = chachedPosition.CurFramePosition;
        }
    }
}
