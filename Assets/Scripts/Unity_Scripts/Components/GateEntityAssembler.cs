using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class GateEntityAssembler : MonoBehaviour
{
    [Inject] private Config _config = null;
    [Inject] private EcsWorld _world = null;
    [SerializeField] private Transform _gate = null;
    [SerializeField] private Transform _pad = null;
    [SerializeField] private Transform _trigger = null;

    void Start()
    {
        //Init Trigger
        int triggerEntity = _world.NewEntity();
        var triggerPool = _world.GetPool<Trigger>();

        ref var triggerComponent = ref triggerPool.Add(triggerEntity);
        triggerComponent.Init(_trigger);

        //Add movement to trigger pad
        var moverPool = _world.GetPool<TriggerMoveResponder>();
        ref var moveComponent = ref moverPool.Add(triggerEntity);
        moveComponent.Init(_pad, triggerEntity, _config.PadMoveDistance);

        //Init Moving Gate
        var gateEntity = _world.NewEntity();
        moveComponent = ref moverPool.Add(gateEntity);
        moveComponent.Init(_gate, triggerEntity, _config.GateMoveDistance);
    }
}
