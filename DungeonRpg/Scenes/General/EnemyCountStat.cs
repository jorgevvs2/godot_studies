using DungeonRPG.General.Events;
using Godot;
using System;

public partial class EnemyCountStat : Label
{
    public override void _Ready()
    {
        GameEvents.OnNewEnemyCount += UpdateEnemyCount;
        Text = "0";
    }

    private void UpdateEnemyCount(int count)
    {
        Text = count.ToString();
        if (count == 0) 
        {
            GameEvents.RaiseGameVictory();
        }
    }
}
