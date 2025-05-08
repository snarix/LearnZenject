using UnityEngine;

namespace _Source.Gameplay
{
    [CreateAssetMenu(menuName = "MetaGameplay/Gameplay/SpawnConfig")]
    public class SpawnConfig : ScriptableObject
    {
        [field: SerializeField] public float SpawnBetweenTimes { get; private set; }
    }
}