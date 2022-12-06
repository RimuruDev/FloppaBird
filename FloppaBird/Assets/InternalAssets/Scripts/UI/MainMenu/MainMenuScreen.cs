using Pausing;
using UnityEngine;
using Zenject;

namespace UI.MainMenuScreen
{
    public class MainMenuScreen : MonoBehaviour
    {
        [Inject] private GamePause _pause;

        private void Start()
        {
            _pause.Pause();
        }

        public void PlayGame()
        {
            _pause.Resume();
            gameObject.SetActive(false);
        }
    }
}