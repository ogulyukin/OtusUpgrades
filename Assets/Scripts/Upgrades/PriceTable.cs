using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Upgrades
{
        [Serializable]
        public sealed class PriceTable
        {
            [Space]
            [SerializeField]
            private int basePrice;

            [Space]
            [ListDrawerSettings(OnBeginListElementGUI = "DrawLevels")]
            [SerializeField]
            private int[] levels;

            public int GetPrice(int level)
            {
                var index = level - 1;
                index = Mathf.Clamp(index, 0, this.levels.Length - 1);
                return this.levels[index];
            }

            private void DrawLevels(int index)
            {
                GUILayout.Space(8);
                GUILayout.Label($"Level #{index + 1}");
            }
        
            public void OnValidate(int maxLevel)
            {
                this.EvaluatePriceTable(maxLevel);
            }

            private void EvaluatePriceTable(int maxLevel)
            {
                var table = new int[maxLevel];
                table[0] = new int();
                for (var level = 2; level <= maxLevel; level++)
                {
                    var price = this.basePrice * level;
                    table[level - 1] = price;
                }

                this.levels = table;
            }
        } 
}
