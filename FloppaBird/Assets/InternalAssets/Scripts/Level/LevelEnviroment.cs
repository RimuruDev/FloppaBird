using Level.Generation;
using Pausing;
using Player;
using UnityEngine;
using Zenject;

namespace Level
{
    [RequireComponent(typeof(LevelGenerator))]
    public class LevelEnviroment : MonoBehaviour, IPauseHandler
    {
        public Transform Container { get => _levelContainer; }

        [SerializeField] private Transform _levelContainer;
        [SerializeField] private float _movementSpeed = 1f;

        [Inject] private PlayerBird _bird;
        [Inject] private GamePause _pause;
        private bool _isMoving;

        public void StartLevelMovement()
        {
            _isMoving = true;
        }
        public void StopLevelMovement()
        {
            _isMoving = false;
        }
        public void Pause()
        {
            StopLevelMovement();
        }
        public void Resume()
        {
            StartLevelMovement();
        }

        private void Awake()
        {
            _bird.OnDeath += birdDied;
            _pause.Register(this);
        }
        private void Update()
        {
            if (!_isMoving)
                return;

            _levelContainer.Translate(Vector3.left * _movementSpeed * Time.deltaTime);
        }
        private void OnDestroy()
        {
            _bird.OnDeath -= birdDied;
            _pause.UnRegister(this);
        }
        private void birdDied(PlayerBird bird)
        {
            StopLevelMovement();
        }
    }
}