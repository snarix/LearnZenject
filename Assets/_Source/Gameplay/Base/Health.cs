using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Source.Gameplay.Base
{
    public class Health : IDamageable
    {
        private int _currentHealth;
        public event Action Died;
        
        public Health(int maxHealth) => _currentHealth = maxHealth;

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Die();
            }
        }
        
        private void Die() => Died?.Invoke();
    }
}