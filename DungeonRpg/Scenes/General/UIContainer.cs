using DungeonRPG.Scenes.General;
using Godot;
using System;

public partial class UIContainer : VBoxContainer
{
    [Export] public ContainerType container { get; private set; }
    [Export] public Button StartButton { get; private set; }
}
