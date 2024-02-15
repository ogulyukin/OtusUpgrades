using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Upgrades
{
    public abstract class UpgradeConfig : ScriptableObject
    {
        protected const float SPACE_HEIGHT = 10.0f;

        [SerializeField]
        public string id;
        
        [Range(2, 99)]
        [SerializeField]
        public int maxLevel = 2;

        [Space(SPACE_HEIGHT)]
        [SerializeField]
        private PriceTable priceTable;
        [Tooltip("Upgrades which affect levelUp")]
        [SerializeField] private UpgradeConfig[] linkedUpgrades;

        public abstract Upgrade InstantiateUpgrade();

        protected virtual void OnValidate()
        {
            try
            {
                Validate();
            }
            catch (Exception)
            {
                // ignored
            }
        }
        
        protected virtual void Validate()
        {
            priceTable.OnValidate(maxLevel);
        }
        
        
        public int GetPrice(int level)
        {
            return priceTable.GetPrice(level);
        }

        public string[] GetLinkedUpgrades()
        {
            var resultArray = new string[linkedUpgrades.Length];
            for (var i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = linkedUpgrades[i].id;
            }
            return resultArray;
        }
    }
}