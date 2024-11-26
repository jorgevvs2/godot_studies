using DungeonRPG.General.Events;
using Godot;
using System;

public partial class Camera : Camera3D
{
    [Export] private Node target;
    [Export] private Node deathTarget;
    [Export] private Vector3 positionFromTarget;

    public override void _Ready()
    {
        GameEvents.OnStartGame += HandleStartGame;
        GameEvents.OnEndGame += HandleEndGame;
    }

    private void HandleEndGame()
    {
        GD.Print("AAAAAAAAAAAAAA");
        Reparent(deathTarget);
    }

    private void HandleStartGame()
    {
        Reparent(target);

        Position = positionFromTarget;
    }
}
