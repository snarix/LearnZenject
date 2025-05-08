using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace _Source.Gameplay
{
    public class EnemyFactory : IEnemyFactory, IEnemyCreateNotifier, IEnemyDeathNotifier
    {
        private Enemy _enemyPrefab;
        private DiContainer _container;
        
        public EnemyFactory(Enemy enemyPrefab, DiContainer container)
        {
            _enemyPrefab = enemyPrefab;
            _container = container;
        }

        public event Action<Enemy> EnemySpawned;
        public event Action<Enemy> Died;
        
        public Enemy Create(Vector3 position)
        {
            var newEnemy = Object.Instantiate(_enemyPrefab, position, Quaternion.identity);
            _container.Inject(newEnemy);
            EnemySpawned?.Invoke(newEnemy);
            newEnemy.Died += OnDied;
            return newEnemy;
        }

        private void OnDied(Enemy newEnemy)
        {
            newEnemy.Died -= OnDied;
            Died?.Invoke(newEnemy);
        }
    }

    public interface IEnemyFactory
    {
        Enemy Create(Vector3 position);
    }

    public interface IEnemyCreateNotifier
    {
        event Action<Enemy> EnemySpawned;
    }

    public class ZenjectEnemyFactory : PlaceholderFactory<Enemy>
    {
        
    }
}