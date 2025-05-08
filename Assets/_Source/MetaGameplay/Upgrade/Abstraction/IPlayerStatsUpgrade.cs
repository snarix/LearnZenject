using _Source.MetaGameplay.UpgradeView;

namespace _Source.MetaGameplay.Upgrade
{
    public interface IPlayerStatsUpgrade
    {
        void Apply();
        void Accept(IUpgradeVisitor upgradeVisitor);
        UpgradeType Type { get; }
    }
}