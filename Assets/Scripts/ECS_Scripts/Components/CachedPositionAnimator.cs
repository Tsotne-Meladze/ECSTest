using UnityEngine;

public struct CachedPositionAnimator
{
    public Animator Animator;
    public int CachedPositionEntity;
    public int BoolAnimHashID;

    public void Init(Animator animator, int boolAnimHashID, int cachedPositionEntity)
    {
        Animator = animator;
        BoolAnimHashID = boolAnimHashID;
        CachedPositionEntity = cachedPositionEntity;
    }
}