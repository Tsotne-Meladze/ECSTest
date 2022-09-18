using UnityEngine;
using Zenject;
using Leopotam.EcsLite;

public class MainInstaller : MonoInstaller
{
    [SerializeField] private ECSController _ecsController = null;
    [SerializeField] private Config _configuration = null;

    public override void InstallBindings()
    {
        Container.Bind<EcsWorld>().FromInstance(_ecsController.Init()).AsSingle().NonLazy();
        Container.Bind<Config>().FromInstance(_configuration).AsSingle().NonLazy();
    }
}