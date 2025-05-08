using UnityEngine;

namespace _Source.Gameplay
{
    [CreateAssetMenu(fileName = "RewardConfig", menuName = "Gameplay/RewardConfig")]
    public class RewardConfig : ScriptableObject
    {
        [field: SerializeField] public int AmountForDie { get; private set; }
    }
}