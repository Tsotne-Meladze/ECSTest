using UnityEngine;

public struct Trigger
{
    public Transform Transform;
    public bool IsActive;

    public void Init(Transform transform)
    {
        Transform = transform;
    }
}