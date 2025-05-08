using _Source.Gameplay.Base;
using Include;
using UnityEngine;
using Zenject;

namespace _Source.Gameplay.PlayerShooter
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] private Transform _bulletSpawnPoint;
        
        private PlayerStats _playerStats;
        private BulletConfig _bulletConfig;
        private Health _health;
        private IInputSystem _inputSystem;
        
        [Inject]
        public void Construct(IInputSystem inputSystem, BulletConfig bulletConfig, PlayerStats playerStats)
        {
            _inputSystem = inputSystem;
            _playerStats = playerStats;
            
            _bulletConfig = bulletConfig;
            _health = new Health(_playerStats.MaxHealth);
            
            _inputSystem.Clicked += OnClick;
            _health.Died += OnDied;
        }

        private void Update()
        {
            var target = _inputSystem.CurrentPointerPosition;
            transform.LookAt(target);
        }

        private void OnClick(Vector3 targetPosition)
        {
            Shoot(targetPosition);
        }

        private void OnDestroy()
        {
            _health.Died -= OnDied;
            _inputSystem.Clicked -= OnClick;
        } 
        
        public void Hit(int damage) => _health.TakeDamage(damage);

        private void Shoot(Vector3 target)
        {
            var bullet = Instantiate(_bulletConfig.Bullet, _bulletSpawnPoint.position, Quaternion.identity);
            Vector3 direction = (target - _bulletSpawnPoint.position).normalized;
            bullet.Initialize(direction, _bulletConfig, _playerStats);
        }
        
        private void OnDied() => Destroy(gameObject);
    }
}