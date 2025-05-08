using _Source.MetaGameplay.Upgrade;
using _Source.MetaGameplay.UpgradeView;
using UnityEngine;
using Zenject;

public class MetaGameplayInstaller : MonoInstaller
{
    [SerializeField] private UpgradeButtonFactory _upgradeButtonFactory;
    [SerializeField] private UpgradePanelView _upgradePanelView;
    [SerializeField] private UpgradeConfigHolder _upgradeConfig;
    
    public override void InstallBindings()
    {
        Container.Bind<UpgradePanelView>().FromInstance(_upgradePanelView).AsSingle();
        Container.Bind<IUpgradeButtonFactory>().To<UpgradeButtonFactory>().FromInstance(_upgradeButtonFactory).AsSingle();
        Container.Bind<UpgradeConfigHolder>().FromInstance(_upgradeConfig).AsSingle();
        Container.Bind<UpgradeApplier>().AsSingle().NonLazy(); ;
    }
}