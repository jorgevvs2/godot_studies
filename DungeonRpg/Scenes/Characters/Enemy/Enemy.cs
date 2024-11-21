using DungeonRPG.Scenes.Common;
using Godot;
using System;

public partial class Enemy : Character
{
	[Export] Label3D Label { get; set; }

	public override void _Process(double delta)
	{
		base._PhysicsProcess(delta);
		Label.Text = StateMachine.currentState.GetType().Name;
	}
}
