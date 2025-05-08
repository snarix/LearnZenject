using System;
using System.Collections.Generic;

namespace _Source.Gameplay
{
    public abstract class EnemyDeath
    {
        private IEnemyCreateNotifier _createNotifier;
        private List<Enemy> _enemies = new List<Enemy>();

        public EnemyDeath(IEnemyCreateNotifier createNotifier)
        {
            _createNotifier = createNotifier;
            _createNotifier.EnemySpawned += OnEnemySpawned;
        }
        
        public void Dispose()
        {
            _createNotifier.EnemySpawned -= OnEnemySpawned;
        }

        private void OnEnemySpawned(Enemy enemy)
        {
            enemy.Died += OnEnemyDied;
            _enemies.Add(enemy);
        }

        private void OnEnemyDied(Enemy enemy)
        {
            enemy.Died -= OnEnemyDied;
            _enemies.Remove(enemy);
            EnemyDied();
        }

        protected abstract void EnemyDied();
    }
}