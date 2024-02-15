using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "SpeedUpgradeConfig", menuName = "Upgrades/StatUpgradeConfig")]
    public sealed class StatUpgradeConfig : UpgradeConfig
    {
        public StatUpgradeTable statUpgradeTable;
        public string statName; 
        
        public override Upgrade InstantiateUpgrade()
        {
            throw new System.NotImplementedException();
        }


        protected override void OnValidate()
        {
            base.OnValidate();
            statUpgradeTable.OnValidate(maxLevel);
        }
    }
}
