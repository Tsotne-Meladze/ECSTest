using Leopotam.EcsLite;

public class PlayerAnimatorSystem : IEcsRunSystem, IEcsInitSystem
{
    private EcsWorld _world;

    private EcsFilter _cachPosAnimEntities;
    private EcsPool<CachedPositionAnimator> _cachPosAnimPool;
    private EcsPool<CachedPosition> _cachPosPool;

    public void Init(IEcsSystems systems)
    {
        _world = systems.GetWorld();

        _cachPosAnimEntities = _world.Filter<CachedPositionAnimator>().End();
        _cachPosAnimPool = _world.GetPool<CachedPositionAnimator>();
        _cachPosPool = _world.GetPool<CachedPosition>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach(var e in _cachPosAnimEntities)
        {
            ref var cachPosAnim = ref _cachPosAnimPool.Get(e);
            ref var cachPos = ref _cachPosPool.Get(cachPosAnim.CachedPositionEntity);

            cachPosAnim.Animator.SetBool(cachPosAnim.BoolAnimHashID, cachPos.ChangeInPositionDetected);
        }
    }
}