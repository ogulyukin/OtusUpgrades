using Tool;
using UnityEngine;
using Upgrades;
using Zenject;

namespace DI
{
    public sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private PlayerEntity playerEntity;

        [SerializeField] private TestUpgrade testUpgrade;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerEntity>().FromInstance(playerEntity);
            Container.Bind<Player>().AsSingle();
            Container.Bind<MoneyStorage>().AsSingle();
            Container.Bind<TestUpgrade>().FromInstance(testUpgrade);
            Container.Bind<UpgradesManager>().AsSingle();
        }
    }
}