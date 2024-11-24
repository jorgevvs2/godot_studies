using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRPG.General.Events
{
    public class GameEvents
    {
        public static Action OnStartGame;
        public static void RaiseStartGame()
        {
            OnStartGame?.Invoke();
        }
    }
}
