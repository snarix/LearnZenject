using _Source.Gameplay.PlayerShooter;
using _Source.MetaGameplay.UpgradeView;

namespace _Source.MetaGameplay.Upgrade
{
    public class DamageUpgrade : PlayerStatsUpgrade
    {
        private int _value;
        
        public DamageUpgrade(PlayerStats playerStats, UpgradeConfig upgradeConfig, int value) : base(playerStats, upgradeConfig)
        {
            _value = value;
        }

        public override void Apply()
        {
            _playerStats.Damage += _value;
        }

        public override UpgradeType Type => UpgradeType.DamageUpgrade;

        public override int GetCurrentValue() => _playerStats.Damage;

        public override int GetNextValue() => _playerStats.Damage + _value;
        
        public override int GetValue() => _value;
    }
}