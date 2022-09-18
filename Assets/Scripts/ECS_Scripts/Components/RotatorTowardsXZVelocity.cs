using UnityEngine;

public struct RotatorTowardsXZVelocity
{
    public Transform Transform;
    public Vector3 PrevFramePosition;
    public Vector3 CurFramePosition => Transform.position;
    public bool ChangeInPositionDetected => CurFramePosition != PrevFramePosition;

    public void Init(Transform transform)
    {
        Transform = transform;
    }
}