using Leopotam.EcsLite;
using UnityEngine;

public class GateOpenSystem : IEcsRunSystem
{
    private Gate[] _gates;

    public void Run(IEcsSystems systems)
    {
        Vector3 targetPosition = Vector3.zero;
        float maxDistanceDelta = Time.deltaTime * 1f;

        foreach(var gate in _gates)
        {
            targetPosition = gate.TriggerPad.IsPressed ? gate.OpenPosition : gate.ClosePosition;

            gate.Transform.position = Vector3.MoveTowards(gate.Transform.position, targetPosition, maxDistanceDelta);
        }
    }
}

public struct Gate
{
    public Transform Transform;
    public TriggerPad TriggerPad;
    public Vector3 OpenPosition;
    public Vector3 ClosePosition;
}

public struct Triggerer
{
    public Transform Transform;
}