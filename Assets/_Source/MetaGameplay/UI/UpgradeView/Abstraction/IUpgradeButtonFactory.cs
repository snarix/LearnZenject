using _Source.MetaGameplay.Upgrade;
using UnityEngine;

namespace _Source.MetaGameplay.UpgradeView
{
    public interface IUpgradeButtonFactory
    {
        UpgradeButtonView Create(IPlayerStatsUpgrade playerStatsUpgrade, Transform parentTransform);
    }
}