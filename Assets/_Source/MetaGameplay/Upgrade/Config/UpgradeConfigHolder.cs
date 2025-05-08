using System.Collections.Generic;
using _Source.MetaGameplay.UpgradeView;
using UnityEngine;

namespace _Source.MetaGameplay.Upgrade
{
    [CreateAssetMenu(menuName = "MetaGameplay/Upgrade/UpgradeConfigHolder")]
    public class UpgradeConfigHolder : ScriptableObject
    {
        [field: SerializeField] public List<UpgradeConfig> Upgrades { get; set; }

        public T GetUpgradeConfig<T>(UpgradeType upgradeType) where T : UpgradeConfig
        {
            var upgradeData = Upgrades.Find(bonus => bonus.UpgradeType == upgradeType);
            if (upgradeData != null && upgradeData is T)
                return (T)upgradeData;

            throw new System.Exception($"No upgrade found for type {typeof(T)} of {upgradeType}");
        }
    }
}