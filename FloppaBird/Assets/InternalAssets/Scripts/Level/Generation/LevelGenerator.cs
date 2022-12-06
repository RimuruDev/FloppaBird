using Level.Generation.Factories;
using Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Level.Generation
{
    [RequireComponent(typeof(LevelEnviroment))]
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField, Range(10, 40)] private float _newChunkDistance = 20;
        [SerializeField, Range(0, 40)] private float _destroyChunkDistance = 20;

        [Inject] private ChunkFactory _factory;
        [Inject] private PlayerBird _playerBird;
        private LevelEnviroment _enviroment;
        private List<Chunk> _chunks = new List<Chunk>();

        private void Awake()
        {
            _enviroment = GetComponent<LevelEnviroment>();

            createNewChunk(true);
        }

        private void Update()
        {
            if (_playerBird.transform.position.x > _chunks.Last().EndMarker.position.x - _newChunkDistance)
            {
                createNewChunk();
            }

            if (_playerBird.transform.position.x > _chunks.First().EndMarker.position.x + _destroyChunkDistance)
            {
                destroyFarestChunk();
            }
        }

        private void createNewChunk()
        {
            createNewChunk(false);
        }
        private void createNewChunk(bool first)
        {
            Chunk newChunk = first ? _factory.CreateFirstChunk() : _factory.CreateRandom();
            newChunk.transform.SetParent(_enviroment.Container);

            newChunk.transform.position = _chunks.Count() != 0 ? _chunks.Last().EndMarker.position - newChunk.StartMarker.position : Vector3.zero;

            _chunks.Add(newChunk);
        }
        private void destroyFarestChunk()
        {
            Chunk chunkToDestroy = _chunks.First();
            _chunks.Remove(chunkToDestroy);
            chunkToDestroy.Destroy();
        }
    }
}