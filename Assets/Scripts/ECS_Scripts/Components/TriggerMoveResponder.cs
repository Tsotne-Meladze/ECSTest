using UnityEngine;

public struct TriggerMoveResponder
{
    public Transform Transform;
    public int Trigger;
    public Vector3 PassivePosition;
    public Vector3 ActivePosition;

    public void Init(Transform transform, int triggerEntity, Vector3 movementOffset)
    {
        Transform = transform;
        Trigger = triggerEntity;
        PassivePosition = transform.localPosition;
        ActivePosition = transform.localPosition + movementOffset;
    }
}
