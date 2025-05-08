using System;

namespace _Source.Gameplay
{
    public interface IEnemyDeathNotifier
    {
        event Action<Enemy> Died;
    }
}