using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Upgrades;
using Zenject;

namespace Tool
{
    public sealed class TestUpgrade : MonoBehaviour
    {
        [SerializeField] private SpeedUpgradeConfig config;
        [SerializeField] private StatUpgradeConfig[] statConfigs; 
        [ShowInInspector] private SpeedUpgrade speedUpgrade;
        [ShowInInspector] private List<StatUpgrade> statUpgrades = new();
        [SerializeField] private PlayerEntity player;
        [ShowInInspector] private UpgradesManager upgradesManager;
        private MoneyStorage moneyStorage;
        [SerializeField] private int moneyAmountToAdd = 100;
        [Button]
        private void AddMoneyToStorage()
        {
            moneyStorage.EarnMoney(moneyAmountToAdd);
        }

        [Inject]
        private void Construct(UpgradesManager manager, MoneyStorage storage)
        {
            speedUpgrade = new SpeedUpgrade(config, player);
            foreach (var statConfig in statConfigs)
            {
                statUpgrades.Add(new StatUpgrade(statConfig, player));
            }
            moneyStorage = storage;
            upgradesManager = manager;
            var upgradesList = new List<Upgrade>();
            upgradesList.AddRange(statUpgrades);
            upgradesList.Add(speedUpgrade);
            upgradesManager.Setup(upgradesList.ToArray());
        }

        private void OnEnable()
        {
            moneyStorage.OnMoneyEarned += AddMoneyCheck;
        }

        private void OnDisable()
        {
            moneyStorage.OnMoneyEarned -= AddMoneyCheck;
        }

        private void AddMoneyCheck(int amount)
        {
            Debug.Log($"Money added: {amount}");
        }
    }
}
