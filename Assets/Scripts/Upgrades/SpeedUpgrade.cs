
namespace Upgrades
{
    public sealed class SpeedUpgrade : Upgrade
    {
        private readonly SpeedUpgradeTable speedUpgradeTable;
        private readonly IEntity hero;

        public SpeedUpgrade(SpeedUpgradeConfig config, IEntity hero) : base(config)
        {
            speedUpgradeTable = config.speedUpgradeTable;
            this.hero = hero;
        }

        protected override void LevelUp(int level)
        {
            if (hero.TryComponent(out PlayerStats playerStats))
            {
                playerStats.ChangeStat("Speed", speedUpgradeTable.GetSpeed(level));
            }
        }
    }
}
