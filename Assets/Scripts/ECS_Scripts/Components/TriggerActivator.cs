using UnityEngine;

public struct TriggerActivator
{
    public Transform Transform;

    public void Init(Transform transform)
    {
        Transform = transform;
    }
}