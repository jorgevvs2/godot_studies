using DungeonRPG.General.Events;
using DungeonRPG.Scenes.Characters.Resources;
using Godot;
using System;

public partial class StatLabel : Label
{
    [Export] private StatResource resource;

    public override void _Ready()
    {
        resource.OnUpdate += StatResource_OnUpdate;
        Text = resource.StatValue.ToString();
    }

    private void StatResource_OnUpdate()
    {
        Text = resource.StatValue.ToString();
    }
}
