using DungeonRPG.Scenes.General;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class UIController : Control
{
    private Dictionary<ContainerType, UIContainer> containers;

    public override void _Ready()
    {
        containers = GetChildren()
            .Where((element) => element is UIContainer)
            .Cast<UIContainer>()
            .ToDictionary((element) => element.container);

        containers[ContainerType.Start].Visible = true;

        containers[ContainerType.Start].StartButton.Pressed += HandleStartPressed;
    }

    private void HandleStartPressed()
    {
        GD.Print("Start pressed");
        GetTree().Paused = false;

        containers[ContainerType.Start].Visible = false;
    }
}
