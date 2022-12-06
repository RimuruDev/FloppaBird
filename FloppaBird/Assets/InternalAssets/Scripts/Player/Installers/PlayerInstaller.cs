using Zenject;
using UnityEngine;

namespace Player.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerBird _playerBird;

        public override void InstallBindings()
        {
            Container.Bind<PlayerBird>().FromInstance(_playerBird).AsSingle().NonLazy();
        }
    }
}