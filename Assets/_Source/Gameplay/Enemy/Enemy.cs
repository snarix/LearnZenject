using System;
using _Source.Gameplay.Base;
using _Source.Gameplay.PlayerShooter;
using UnityEngine;
using Zenject;

namespace _Source.Gameplay
{
    public class Enemy : MonoBehaviour
    {
        private IEnemyConfigHolder _enemyConfigHolder;
        private Health _health;
        private Shooter _shooter;

        private int _damage;
        private float _speed;

        public event Action<Enemy> Died;

        [Inject]
        public void Construct(IEnemyConfigHolder enemyConfig, Shooter shooter)
        {
            _enemyConfigHolder = enemyConfig;
            _shooter = shooter;
            var config = _enemyConfigHolder.GetConfig();
            
            _damage = config.Damage;
            _speed = config.Speed;
            _health = new Health(config.MaxHealth);
            _health.Died += OnDied;
        }
        
        private void Update()
        {
            MoveToShooterPosition();
        }

        private void OnDestroy()
        {
            if (_health != null)
                _health.Died -= OnDied;
        }
        
        public void Hit(int damage) => _health.TakeDamage(damage);
        
        private void MoveToShooterPosition()
        {
            if (_shooter != null)
            {
                var pos = _shooter.transform.position;
                Vector3 direction = (pos - transform.position).normalized;
                transform.position += direction * (_speed * Time.deltaTime);
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var shooter = other.GetComponent<Shooter>();
            if (shooter)
            {
                shooter.Hit(_damage);
                Destroy(gameObject);
            }
        }

        private void OnDied()
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}