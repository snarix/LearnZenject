using UnityEngine;

namespace _Source.Gameplay.PlayerShooter
{
    [CreateAssetMenu(fileName = "New Difficulty", menuName = "New Difficulty")]
    public class Difficulty : ScriptableObject
    {
        [SerializeField] private DifficultyLevel _difficultyLevel;
        [SerializeField] private EnemyConfig _enemyConfig;
        
        public DifficultyLevel DifficultyLevel => _difficultyLevel;

        public EnemyConfig EnemyConfig => _enemyConfig;
    }
}