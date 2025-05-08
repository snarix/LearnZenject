using System;
using _Source.MetaGameplay.Upgrade;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.MetaGameplay.UpgradeView
{
    public class UpgradeButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        [SerializeField] private TextMeshProUGUI _initialText;
        [SerializeField] private TextMeshProUGUI _valueText;
        [SerializeField] private TextMeshProUGUI _endText;
        
        private UpgradeType _currentUpgrade;
        
        public event Action<UpgradeType> ApplyClicked;

        private PlayerStatsUpgrade _playerStatsUpgrade;

        public void Initialize(UpgradeType upgradeType, PlayerStatsUpgrade playerStatsUpgrade)
        {
            _currentUpgrade = upgradeType;
            _playerStatsUpgrade = playerStatsUpgrade;
            
            _initialText.text = playerStatsUpgrade.GetCurrentValue().ToString();
            _valueText.text = playerStatsUpgrade.GetValue().ToString();
            _endText.text = playerStatsUpgrade.GetNextValue().ToString();
            
            _button.onClick.AddListener(UpgradeClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(UpgradeClick);
        }

        private void UpgradeClick()
        {
            ApplyClicked?.Invoke(_currentUpgrade);
            
            if (_playerStatsUpgrade != null)
            {
                _initialText.text = _playerStatsUpgrade.GetCurrentValue().ToString();
                _valueText.text = _playerStatsUpgrade.GetValue().ToString();
                _endText.text = _playerStatsUpgrade.GetNextValue().ToString();
            }
        }
    }

    public enum UpgradeType
    {
        DamageUpgrade,
        DifficultyLevel
    }
}