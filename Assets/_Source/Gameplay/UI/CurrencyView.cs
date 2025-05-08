using TMPro;
using UnityEngine;
using Zenject;

namespace _Source.Gameplay.UI
{
    public class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currencyText;
        
        [Inject]
        public void Construct(Currency currency)
        {
            _currencyText.text = currency.Value.ToString();
            currency.ValueChanged += OnValueChanged;
        }

        private void OnValueChanged(int value)
        {
            _currencyText.text = value.ToString();
        }
    }
}