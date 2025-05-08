using System;
using UnityEngine;
using Zenject;

namespace _Source.Gameplay
{
    public class Currency
    {
        private int _value;
        
        [Inject]
        public Currency(CurrencyConfig config)
        {
            _value = config.Value;
        }

        public int Value => _value;
        
        public event Action<int> ValueChanged;

        public void AddValue(int amount)
        {
            if(amount <= 0)
                throw new Exception("Amount must be greater than 0");
            
            _value += amount;
            ValueChanged?.Invoke(_value);
        }
    }
}