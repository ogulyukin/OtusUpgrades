using System;
using Sirenix.OdinInspector;

// ReSharper disable ConvertToAutoPropertyWithPrivateSetter

namespace Upgrades
{
    public abstract class Upgrade
    {
        public event Action<int> OnLevelUp;

        [ShowInInspector, ReadOnly]
        public string Id => config.id;

        [ShowInInspector, ReadOnly]
        public int Level => currentLevel;

        [ShowInInspector, ReadOnly]
        public int MaxLevel => config.maxLevel;

        public bool IsMaxLevel => currentLevel == config.maxLevel;

        [ShowInInspector, ReadOnly]
        public float Progress => (float) currentLevel / config.maxLevel;

        [ShowInInspector, ReadOnly]
        public int NextPrice => config.GetPrice(Level + 1);

        [ShowInInspector, ReadOnly] public string[] LinkedUpgrades => config.GetLinkedUpgrades();

        private readonly UpgradeConfig config;

        private int currentLevel;

        protected Upgrade(UpgradeConfig config)
        {
            this.config = config;
            currentLevel = 1;
        }

        public void SetupLevel(int level)
        {
            currentLevel = level;
        }

        public void LevelUp()
        {
            if (Level >= MaxLevel)
            {
                throw new Exception($"Can not increment level for upgrade {this.config.id}!");
            }

            var nextLevel = Level + 1;
            currentLevel = nextLevel;
            LevelUp(nextLevel);
            OnLevelUp?.Invoke(nextLevel);
        }

        protected abstract void LevelUp(int level);
    }
}