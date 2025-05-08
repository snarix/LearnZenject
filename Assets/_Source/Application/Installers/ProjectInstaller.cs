using _Source.Gameplay.PlayerShooter;
using Include;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    [SerializeField] private PlayerConfig _playerConfig;
    
    public override void InstallBindings()
    {
        Container.Bind<IScenesLoadingService>().To<ZenjectScenesLoadingService>().AsSingle();
        Container.Bind<ICoroutineHandler>().To<MonoBehaviourCoroutineHandler>().AsSingle().WithArguments(this);
        Container.Bind<PlayerStats>().AsSingle().WithArguments(_playerConfig.Damage, _playerConfig.DifficultyLevel, _playerConfig.MaxHealth);
    }
}