using System;
using UnityEngine;

namespace _Source.Gameplay.Base
{
    public interface IDamageable
    {
        void TakeDamage(int damage);
        event Action Died;
    }
}