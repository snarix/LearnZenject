using UnityEngine;
using Zenject;

public class InitializationInstaller : MonoInstaller
{
    [SerializeField] InitializationUIRoot _uiRoot;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InitializationBootstrap>().AsSingle().NonLazy();
        Container.Bind<InitializationUIRoot>().FromInstance(_uiRoot).AsSingle().NonLazy();
    }
}