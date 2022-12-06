using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI.MainDeathScreen
{
    public class MainDeathScreen : MonoBehaviour
    {
        [Inject] private PlayerBird _playerBird;

        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }

        private void Awake()
        {
            _playerBird.OnDeath += playerBirdDied;
            gameObject.SetActive(false);
        }
        private void OnDestroy()
        {
            _playerBird.OnDeath -= playerBirdDied;
        }
        private void playerBirdDied(PlayerBird bird)
        {
            gameObject.SetActive(true);
        }
    }
}