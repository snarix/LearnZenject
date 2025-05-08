using _Source.MetaGameplay.UpgradeView;
using UnityEngine;

namespace _Source.MetaGameplay.Upgrade
{
    [CreateAssetMenu(menuName = "MetaGameplay/Upgrade/Upgrade Config")]
    public class UpgradeConfig : ScriptableObject
    {
        [SerializeField] private UpgradeType _upgradeType;
        [SerializeField] private int _upgradeValue;

        public UpgradeType UpgradeType => _upgradeType;
        public int UpgradeValue => _upgradeValue;
    }
}