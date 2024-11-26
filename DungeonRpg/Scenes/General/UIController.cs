using DungeonRPG.General.Constants;
using DungeonRPG.General.Events;
using DungeonRPG.Scenes.General;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class UIController : Control
{
    private Dictionary<ContainerType, UIContainer> containers;
    private bool CanPause = false;

    public override void _Ready()
    {
        containers = GetChildren()
            .Where((element) => element is UIContainer)
            .Cast<UIContainer>()
            .ToDictionary((element) => element.container);

        containers[ContainerType.Start].Visible = true;
        containers[ContainerType.Victory].Visible = false;


        containers[ContainerType.Start].StartButton.Pressed += HandleStartPressed;
        containers[ContainerType.Pause].StartButton.Pressed += HandlePausePressed;
        GameEvents.OnEndGame += HandleGameEnded;
        GameEvents.OnGameVictory += HandleGameVictory;
    }

    private void HandlePausePressed()
    {
        GetTree().Paused = false;

        containers[ContainerType.Pause].Visible = false;
        containers[ContainerType.Stats].Visible = true;
    }


    public override void _Input(InputEvent @event)
    {
        if (!CanPause) { return; }

        if (!Input.IsActionJustPressed(MovementConstants.PAUSE))
        {
            return;
        }

        containers[ContainerType.Stats].Visible = GetTree().Paused;
        GetTree().Paused = !GetTree().Paused;
        containers[ContainerType.Pause].Visible = GetTree().Paused;
    }


    private void HandleGameVictory()
    {
        CanPause = false;
        containers[ContainerType.Stats].Visible = false;
        containers[ContainerType.Victory].Visible = true;
        GetTree().Paused = true;    
    }

    private void HandleGameEnded()
    {
        CanPause = false;

        containers[ContainerType.Stats].Visible = false;
        containers[ContainerType.Defeat].Visible = true;
    }

    private void HandleStartPressed()
    {
        CanPause = true;
        GetTree().Paused = false;

        GameEvents.RaiseStartGame();
        containers[ContainerType.Start].Visible = false;
        containers[ContainerType.Stats].Visible = true;
    }
}
