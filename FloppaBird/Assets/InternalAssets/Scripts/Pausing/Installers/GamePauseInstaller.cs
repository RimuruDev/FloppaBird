using Zenject;
using UnityEngine;

namespace Pausing.Installers
{
    public class GamePauseInstaller : MonoInstaller
    {
        [SerializeField] private GamePause _gamePause;

        public override void InstallBindings()
        {
            Container.Bind<GamePause>().FromInstance(_gamePause).AsSingle().NonLazy();
        }
    }
}
