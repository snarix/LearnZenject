using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Gameplay
{
    [Serializable]
    public class SpawnData
    {
        [SerializeField] private List<Transform> _spawnPositions;
        [SerializeField, Range(0, 60)] private float _timeBetweenSpawn;

        public List<Transform> SpawnPositions => _spawnPositions;

        public float TimeBetweenSpawn => _timeBetweenSpawn;
    }
}