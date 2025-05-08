using System;
using Zenject;

namespace _Source.Gameplay
{
    public class RewardGiver : IDisposable
    {
        private Currency _currency;
        private RewardConfig _rewardConfig;
        private IEnemyDeathNotifier _createNotifier;

        [Inject]
        public RewardGiver(Currency currency, RewardConfig rewardConfig, IEnemyDeathNotifier createNotifier)
        {
            _currency = currency;
            _rewardConfig = rewardConfig;
            _createNotifier = createNotifier;
            
            _createNotifier.Died += OnEnemySpawned;
        }

        private void OnEnemySpawned(Enemy enemy)
        {
            _currency.AddValue(_rewardConfig.AmountForDie);
        }

        public void Dispose()
        {
            _createNotifier.Died -= OnEnemySpawned;
        }
    }
}