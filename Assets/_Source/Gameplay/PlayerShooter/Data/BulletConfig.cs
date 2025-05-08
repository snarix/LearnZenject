using UnityEngine;

namespace _Source.Gameplay.PlayerShooter
{
    [CreateAssetMenu(fileName = "BulletConfig", menuName = "Gameplay/BulletConfig")]
    public class BulletConfig : ScriptableObject
    {
        [field: SerializeField] public Bullet Bullet { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float LifeTime { get; private set; }
    }
}