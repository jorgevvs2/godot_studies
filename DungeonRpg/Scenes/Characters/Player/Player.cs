using DungeonRPG.General.Constants;
using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required")]
    [Export] public AnimationPlayer AnimPlayer { get; set; }
    [Export] public Sprite3D Sprite { get; set; }
    [Export] public StateMachine StateMachine { get; set; }

    public Vector2 direction = new();

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(
            MovementConstants.MOVE_LEFT,
            MovementConstants.MOVE_RIGHT,
            MovementConstants.MOVE_FORWARD,
            MovementConstants.MOVE_BACKWARD
        );
    }

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if(isNotMovingHorizontally)
        {
            return;
        }

        bool isMovingLeft = Velocity.X < 0;
        Sprite.FlipH = isMovingLeft;
    }
}
