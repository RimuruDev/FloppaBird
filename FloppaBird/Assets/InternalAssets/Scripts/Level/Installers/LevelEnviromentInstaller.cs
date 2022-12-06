using Zenject;
using UnityEngine;

namespace Level.Generation.Installers
{
    public class LevelEnviromentInstaller : MonoInstaller
    {
        [SerializeField] private LevelEnviroment _enviroment;

        public override void InstallBindings()
        {
            Container.Bind<LevelEnviroment>().FromInstance(_enviroment).AsSingle().NonLazy();
        }
    }
}
