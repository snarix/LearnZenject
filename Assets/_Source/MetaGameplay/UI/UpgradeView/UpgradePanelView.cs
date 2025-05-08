using System;
using System.Collections.Generic;
using _Source.MetaGameplay.Upgrade;
using _Source.MetaGameplay.UpgradeView;
using UnityEngine;
using Zenject;

public class UpgradePanelView : MonoBehaviour
{
    [SerializeField] private GameObject _upgradePanel;
    
    private List<UpgradeButtonView> _upgradeButtonViews = new List<UpgradeButtonView>();
    private IUpgradeButtonFactory _upgradeButtonFactory;
    
    [Inject]
    public void Construct(IUpgradeButtonFactory upgradeButtonFactory)
    {
        _upgradeButtonFactory = upgradeButtonFactory;
    }

    public event Action<UpgradeType> Clicked; 

    public void Create(List<IPlayerStatsUpgrade> upgrades)
    {
        foreach (var upgrade in upgrades)
        {
            var buttonView = _upgradeButtonFactory.Create(upgrade, _upgradePanel.transform);
            _upgradeButtonViews.Add(buttonView);
            buttonView.ApplyClicked += OnApplyClicked;
        }
    }
    
    private void OnDestroy()
    {
        foreach (var upgradeButtonView in _upgradeButtonViews)
        {
            upgradeButtonView.ApplyClicked -= OnApplyClicked;
        }
        _upgradeButtonViews.Clear();
    }

    private void OnApplyClicked(UpgradeType upgradeType)
    {
        Clicked?.Invoke(upgradeType);
    }
}