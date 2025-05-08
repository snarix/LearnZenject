using _Source.Gameplay.PlayerShooter;
using _Source.MetaGameplay.UpgradeView;

namespace _Source.MetaGameplay.Upgrade
{
    public abstract class PlayerStatsUpgrade : IPlayerStatsUpgrade
    {
        protected PlayerStats _playerStats;
        
        protected PlayerStatsUpgrade(PlayerStats playerStats, UpgradeConfig upgradeConfig)
        {
            _playerStats = playerStats;
            UpgradeConfig = upgradeConfig;
        }
        
        public abstract UpgradeType Type { get; }

        public UpgradeConfig UpgradeConfig { get; }
        
        public abstract void Apply();
        
        public void Accept(IUpgradeVisitor upgradeVisitor)
        {
            upgradeVisitor.Visit(this);
        }
        
        public abstract int GetCurrentValue();
        
        public abstract int GetNextValue();
        public abstract int GetValue();
    }
}