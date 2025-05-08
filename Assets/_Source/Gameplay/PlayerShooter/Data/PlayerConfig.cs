
using UnityEngine;

namespace _Source.Gameplay.PlayerShooter
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Gameplay/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public DifficultyLevel DifficultyLevel { get; private set; }
    }
}