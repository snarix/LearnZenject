using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.PlayerLoop;

namespace _Source.Gameplay.PlayerShooter
{
    public enum DifficultyLevel
    {
        Easy = 0,
        Medium,
        Hard
    }
    
    public class PlayerStats
    {
        public PlayerStats(int damage, DifficultyLevel difficultyLevel, int maxHealth)
        {
            Damage = damage;
            DifficultyLevel = difficultyLevel;
            MaxHealth = maxHealth;
        }

        public int Damage { get; set; }

        public DifficultyLevel DifficultyLevel { get; set; }
        
        public int MaxHealth { get; set; }
    }

    public class DifficultyController : IEnemyConfigHolder
    {
        private PlayerStats _playerStats;
        private List<Difficulty> _difficulties;
        private Dictionary<DifficultyLevel, Difficulty> _difficultiesByLevel;

        public DifficultyController(PlayerStats playerStats, List<Difficulty> difficulties)
        {
            _playerStats = playerStats;
            _difficulties = difficulties;
            _difficultiesByLevel = new Dictionary<DifficultyLevel, Difficulty>();
            foreach (var level in Enum.GetValues(typeof(DifficultyLevel)))
            {
                var difficulty = _difficulties.Find(x => (DifficultyLevel)level == x.DifficultyLevel);
                _difficultiesByLevel.Add((DifficultyLevel)level, difficulty);
            }
        }

        public EnemyConfig GetConfig()
        {
            return _difficultiesByLevel[_playerStats.DifficultyLevel].EnemyConfig;
        }
    }

    public interface IEnemyConfigHolder
    {
        EnemyConfig GetConfig();
    }
}