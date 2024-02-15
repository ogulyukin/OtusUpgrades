
namespace Upgrades
{
    public sealed class StatUpgrade : Upgrade
    {
        private readonly StatUpgradeTable statUpgradeTable;
        private readonly IEntity hero;
        private readonly string statName;

        public StatUpgrade(StatUpgradeConfig config, IEntity hero) : base(config)
        {
            statUpgradeTable = config.statUpgradeTable;
            this.hero = hero;
            statName = config.statName;
        }

        protected override void LevelUp(int level)
        {
            if (hero.TryComponent(out PlayerStats playerStats))
            {
                playerStats.ChangeStat(statName, statUpgradeTable.GetSpeed(level));
            }
        }
    }
}
