using UnityEngine;

namespace Upgrades
{
    [CreateAssetMenu(fileName = "SpeedUpgradeConfig", menuName = "Upgrades/SpeedUpgradeConfig")]
    public sealed class SpeedUpgradeConfig : UpgradeConfig
    {
        public SpeedUpgradeTable speedUpgradeTable;

        public override Upgrade InstantiateUpgrade()
        {
            throw new System.NotImplementedException();
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            speedUpgradeTable.OnValidate(maxLevel);
        }
    }
}
