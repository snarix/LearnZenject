using System;
using System.Collections.Generic;
using _Source.Gameplay.PlayerShooter;
using _Source.MetaGameplay.UpgradeView;
using UnityEngine;
using Zenject;

namespace _Source.MetaGameplay.Upgrade
{
    public class UpgradeApplier : IDisposable
    {
        private List<IPlayerStatsUpgrade> _playerStatsUpgrades;
        private UpgradePanelView _upgradePanelView;
        
        [Inject]
        public UpgradeApplier(PlayerStats playerStats, UpgradePanelView upgradePanelView, UpgradeConfigHolder config)
        {
            _playerStatsUpgrades = new List<IPlayerStatsUpgrade>()
            {
                new DamageUpgrade(playerStats, 
                    config.GetUpgradeConfig<UpgradeConfig>(UpgradeType.DamageUpgrade), 
                    config.GetUpgradeConfig<UpgradeConfig>(UpgradeType.DamageUpgrade).UpgradeValue),
                
                new DifficultyUpgrade(playerStats, 
                    config.GetUpgradeConfig<UpgradeConfig>(UpgradeType.DifficultyLevel), 
                    config.GetUpgradeConfig<UpgradeConfig>(UpgradeType.DifficultyLevel).UpgradeValue)
            };
            
            _upgradePanelView = upgradePanelView;
            _upgradePanelView.Clicked += OnClicked;
            Create();
        }

        private void Create()
        {
            _upgradePanelView.Create(_playerStatsUpgrades);
        }

        private void OnClicked(UpgradeType upgradeType)
        {
            var playerStatsUpgrade = _playerStatsUpgrades.Find(x => x.Type == upgradeType);
            playerStatsUpgrade?.Apply();
        }

        public void Dispose()
        {
            _upgradePanelView.Clicked -= OnClicked;
        }
    }
}