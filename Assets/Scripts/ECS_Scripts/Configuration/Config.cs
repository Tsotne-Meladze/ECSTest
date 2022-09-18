using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Scriptable Object/Config")]
public class Config : ScriptableObject
{
    [Header("Gates")]
    public Vector3 GateMoveDistance;
    public Vector3 PadMoveDistance;
    public float GateMoveSpeed;
    public float PadCollisionDistance;
}
