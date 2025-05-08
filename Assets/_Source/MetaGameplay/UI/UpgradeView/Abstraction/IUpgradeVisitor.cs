using _Source.MetaGameplay.Upgrade;

namespace _Source.MetaGameplay.UpgradeView
{
    public interface IUpgradeVisitor
    {
        void Visit(PlayerStatsUpgrade upgrade);
    }
}