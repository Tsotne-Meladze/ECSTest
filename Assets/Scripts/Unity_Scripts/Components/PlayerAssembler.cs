﻿using Leopotam.EcsLite;
using UnityEngine;
using Zenject;

public class PlayerAssembler : MonoBehaviour
{
    [Inject] private EcsWorld _world = null;
    [SerializeField] private Transform _player = null;

    private void Start()
    {
        //Init Player
        int entity = _world.NewEntity();
        var activatorPool = _world.GetPool<TriggerActivator>();
        ref var activatorComponent = ref activatorPool.Add(entity);
        activatorComponent.Init(_player);
    }
}