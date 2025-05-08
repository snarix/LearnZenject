using UnityEngine;

namespace _Source.Gameplay
{
    [CreateAssetMenu(fileName = "CurrencyConfig", menuName = "Gameplay/CurrencyConfig")]
    public class CurrencyConfig : ScriptableObject
    {
        [field: SerializeField] public int Value { get; private set; }
    }
}