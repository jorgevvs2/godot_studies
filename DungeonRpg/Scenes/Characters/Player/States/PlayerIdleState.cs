using DungeonRPG.General.Constants;
using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        character.Velocity = Vector3.Zero;
        character.MoveAndSlide();
        if (character.direction != Vector2.Zero)
        {
            character.StateMachine.SwitchState<PlayerMoveState>();
        }
    }
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionPressed(MovementConstants.DASH))
        {
            character.StateMachine.SwitchState<PlayerDashState>();
        }
           
    }
    protected override void EnterState() 
    {
        character.AnimPlayer.Play(AnimationConstants.ANIM_IDLE);
    }
}
