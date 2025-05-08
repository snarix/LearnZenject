using Include;
using UnityEngine;

namespace _Source.Gameplay.PlayerShooter
{
    public class Bullet : MonoBehaviour
    {
        private BulletConfig _bulletConfig;
        private PlayerStats _playerConfig;
        private Vector3 _direction;
        
        public void Initialize(Vector3 direction, BulletConfig bulletConfig, PlayerStats playerConfig)
        {
            _bulletConfig = bulletConfig;
            _playerConfig = playerConfig;
            _direction = direction;
            Destroy(gameObject, _bulletConfig.LifeTime);
        }
        
        private void Update() => transform.position += _direction * (_bulletConfig.Speed * Time.deltaTime);

        private void OnTriggerEnter(Collider other)
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.Hit(_playerConfig.Damage);
                Destroy(gameObject);
            }
        }
    }
}