using _Source.Gameplay.PlayerShooter;
using _Source.MetaGameplay.UpgradeView;

namespace _Source.MetaGameplay.Upgrade
{
    public class DifficultyUpgrade : PlayerStatsUpgrade
    {
        private int _value;
        
        public DifficultyUpgrade(PlayerStats playerStats, UpgradeConfig upgradeConfig, int value) : base(playerStats, upgradeConfig)
        {
            _value = value;
        }

        public override void Apply()
        {
            _playerStats.DifficultyLevel += _value;
        }

        public override UpgradeType Type => UpgradeType.DifficultyLevel;

        public override int GetCurrentValue() => (int)_playerStats.DifficultyLevel;

        public override int GetNextValue() => (int)_playerStats.DifficultyLevel + _value;
        
        public override int GetValue() => _value;
    }
}