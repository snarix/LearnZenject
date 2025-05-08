using _Source.MetaGameplay.Upgrade;
using UnityEngine;

namespace _Source.MetaGameplay.UpgradeView
{
    [CreateAssetMenu(menuName = "MetaGameplay/UI/UpgradeButton")]
    public class UpgradeButtonFactory : ScriptableObject, IUpgradeButtonFactory
    {
        public class UpgradeVisitor : IUpgradeVisitor
        {
            private UpgradeButtonView _upgradeButtonView;
            private Transform _parentTransform;
            
            public UpgradeButtonView CurrentButtonView { get; private set; }

            public UpgradeVisitor(UpgradeButtonView upgradeButtonView, Transform parentTransform)
            {
                _upgradeButtonView = upgradeButtonView;
                _parentTransform = parentTransform;
            }

            public void Visit(PlayerStatsUpgrade upgrade)
            {
                var currentUpgrade = Instantiate(_upgradeButtonView, _parentTransform);
                currentUpgrade.Initialize(upgrade.UpgradeConfig.UpgradeType, upgrade);
                CurrentButtonView = currentUpgrade;
            }
        }
        
        [SerializeField] private UpgradeButtonView _upgradeButtonView;

        public UpgradeButtonView Create(IPlayerStatsUpgrade playerStatsUpgrade, Transform parentTransform)
        {
            var visitor = new UpgradeVisitor(_upgradeButtonView, parentTransform);
            playerStatsUpgrade.Accept(visitor);
            return visitor.CurrentButtonView;
        }
    }
}