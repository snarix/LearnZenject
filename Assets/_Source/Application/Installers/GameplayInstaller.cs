using System.Collections.Generic;
using System.ComponentModel;
using _Source.Gameplay;
using _Source.Gameplay.PlayerShooter;
using Include;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private LayerMask _layer;
    
    [Header("Configs")]
    [SerializeField] private EnemyConfig _enemyConfig;
    [SerializeField] private BulletConfig _bulletConfig;
    [SerializeField] private CurrencyConfig _currencyConfig;
    [SerializeField] private RewardConfig _rewardConfig;
    [SerializeField] private SpawnConfig _spawnConfig;
    [SerializeField] private SpawnData _spawnData;
    
    [Header("Player")]
    [SerializeField] private Shooter _shooterPrefab;
    [SerializeField] private Transform _spawnPoint;
    
    [Header("Enemy")]
    [SerializeField] private Enemy _enemyPrefab;
    
    [SerializeField] private List<Difficulty> _difficulties;
    
    public override void InstallBindings()
    {
        Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();

        Container.BindInterfacesAndSelfTo<InputSystem>().AsSingle().WithArguments(_layer); ;
        
        Container.Bind<EnemyConfig>().FromInstance(_enemyConfig).AsSingle();

        Container.Bind<BulletConfig>().FromInstance(_bulletConfig).AsSingle();

        Container.Bind<CurrencyConfig>().FromInstance(_currencyConfig).AsSingle();
        
        Container.BindInstance(_spawnConfig).AsSingle();

        Container.Bind<Currency>().AsSingle();
        Container.BindInterfacesAndSelfTo<RewardGiver>().AsSingle().NonLazy();
        
        Container.Bind<RewardConfig>().FromInstance(_rewardConfig).AsSingle();
        
        Container.Bind<Shooter>().FromComponentInNewPrefab(_shooterPrefab).AsSingle().OnInstantiated<Shooter>((injectContext, shooter) => shooter.transform.position = _spawnPoint.position).NonLazy();
        
        Container.BindInterfacesAndSelfTo<Enemy>().FromInstance(_enemyPrefab).AsSingle();
        
        Container.BindInterfacesAndSelfTo<EnemyFactory>().AsSingle();
        
        //Container.Bind<IScenesLoadingService>().To<ZenjectScenesLoadingService>().AsSingle();
        
        //Container.Bind<ICoroutineHandler>().To<MonoBehaviourCoroutineHandler>().AsSingle();
        Container.Bind<SpawnData>().FromInstance(_spawnData).AsSingle();
        Container.BindInterfacesAndSelfTo<Spawner>().AsSingle().NonLazy();
        
        Container.BindInterfacesAndSelfTo<DifficultyController>().AsSingle().NonLazy();
        Container.Bind<List<Difficulty>>().FromInstance(_difficulties).AsSingle();
        /*Container.Bind<Difficulty>().FromInstance(_difficulties[0]).AsCached();
        Container.Bind<Difficulty>().FromInstance(_difficulties[1]).AsCached();
        Container.Bind<Difficulty>().FromInstance(_difficulties[2]).AsCached();*/
        
    }
}