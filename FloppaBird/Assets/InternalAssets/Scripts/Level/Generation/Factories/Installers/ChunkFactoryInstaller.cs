using Zenject;
using UnityEngine;

namespace Level.Generation.Factories.Installers
{
    public class ChunkFactoryInstaller : MonoInstaller
    {
        [SerializeField] private ChunkFactory _factory;

        public override void InstallBindings()
        {
            Container.Bind<ChunkFactory>().FromInstance(_factory).AsSingle().NonLazy();
        }
    }
}
