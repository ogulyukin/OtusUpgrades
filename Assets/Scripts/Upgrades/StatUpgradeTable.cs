using System;
using UnityEngine;

namespace Upgrades
{
    [Serializable]
    public sealed class StatUpgradeTable
    {
        [SerializeField] private float start;
        [SerializeField] private float end;
        [field: SerializeField] private float step;
        public float GetSpeed(int level)
        {
            return start + step * (level - 1);
        }

        public void OnValidate(int level)
        {
            step = (end - start) / level;
        }
    }
}
