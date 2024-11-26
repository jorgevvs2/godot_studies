using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRPG.General.Events
{
    public class GameEvents
    {
        public static event Action OnStartGame;
        public static event Action OnEndGame;
        public static event Action OnGameVictory;
        public static event Action<int> OnNewEnemyCount;

        public static void RaiseStartGame() => OnStartGame?.Invoke();
        public static void RaiseEndGame() => OnEndGame?.Invoke();
        public static void RaiseNewEnemyCount(int count) => OnNewEnemyCount?.Invoke(count);
        public static void RaiseGameVictory() => OnGameVictory?.Invoke();
    }
}