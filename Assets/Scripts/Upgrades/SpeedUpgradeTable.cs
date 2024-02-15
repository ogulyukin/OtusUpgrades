using System;
using UnityEngine;

namespace Upgrades
{
    [Serializable]
    public sealed class SpeedUpgradeTable
    {
        [SerializeField] private float startSpeed;
        [SerializeField] private float endSpeed;
        [field: SerializeField] private float speedStep;
        public float GetSpeed(int level)
        {
            return startSpeed + speedStep * level;
        }

        public void OnValidate(int level)
        {
            speedStep = (endSpeed - startSpeed) / level;
        }
    }
}