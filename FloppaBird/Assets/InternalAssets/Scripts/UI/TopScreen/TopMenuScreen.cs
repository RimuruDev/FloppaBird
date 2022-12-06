using Pausing;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace UI.TopMenuScreen
{
    public class TopMenuScreen : MonoBehaviour
    {
        [Inject] private PlayerBird _playerBird;
        [Inject] private GamePause _pause;
        private bool _isPaused = false;

        public void TogglePause()
        {
            _isPaused = !_isPaused;

            if (_isPaused)
                _pause.Pause();
            else
                _pause.Resume();
        }

        private void Awake()
        {
            _playerBird.OnDeath += playerBirdDied;
        }
        private void OnDestroy()
        {
            _playerBird.OnDeath -= playerBirdDied;
        }

        private void playerBirdDied(PlayerBird bird)
        {
            gameObject.SetActive(false);
        }
    }
}