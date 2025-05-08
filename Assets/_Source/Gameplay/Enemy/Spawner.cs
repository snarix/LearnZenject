using UnityEngine;
using Zenject;

namespace _Source.Gameplay
{
    public class Spawner : ITickable
    {
        private SpawnData _spawnConfig;
        private IEnemyFactory _factory;

        private float _nextSpawn;

        [Inject]
        public void Construct(IEnemyFactory factory, SpawnData config)
        {
            _factory = factory;
            _spawnConfig = config;
        }

        public void Tick()
        {
            if (_nextSpawn < Time.time)
            {
                var rndIndex = Random.Range(0, _spawnConfig.SpawnPositions.Count);
                var enemy = _factory.Create(_spawnConfig.SpawnPositions[rndIndex].position);
                _nextSpawn = _spawnConfig.TimeBetweenSpawn + Time.time;
            }
        }
    }
}