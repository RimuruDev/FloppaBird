using System;
using System.Linq;
using UnityEngine;

namespace Level.Generation.Factories
{
    public class ChunkFactory : MonoBehaviour
    {
        [SerializeField] private Chunk[] _prefabs;
        [SerializeField] private Chunk _firstChunk;

        private System.Random _random = new System.Random();
        private Chunk _lastChunkPrefab;

        public Chunk CreateRandom()
        {
            return instantiateChunk(getRandom());
        }
        public Chunk CreateFirstChunk()
        {
            return instantiateChunk(_firstChunk);
        }

        private Chunk instantiateChunk(Chunk chunk)
        {
            Chunk instance = Instantiate(chunk);
            instance.transform.position = Vector3.zero;
            return instance;
        }
        private Chunk getRandom()
        {
            Chunk newTargetChunk = _prefabs[_random.Next(0, _prefabs.Length)];

            if (_lastChunkPrefab != null)
            {
                if (_lastChunkPrefab == newTargetChunk)
                {
                    Chunk[] noLastPrefabs = _prefabs.Where(x => x != _lastChunkPrefab).ToArray();
                    newTargetChunk = noLastPrefabs[_random.Next(0, noLastPrefabs.Length)];
                }
            }

            _lastChunkPrefab = newTargetChunk;
            return newTargetChunk;
        }
    }
}
