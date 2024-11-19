using DungeonRPG.General.Constants;
using Godot;
using System;

public partial class IdleState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        if (character.direction != Vector2.Zero)
        {
            character.StateMachine.SwitchState<MoveState>();
        }
    }
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionPressed(MovementConstants.DASH))
        {
            character.StateMachine.SwitchState<DashState>();
        }
           
    }
    protected override void EnterState() 
    {
        character.AnimPlayer.Play(GameConstants.ANIM_IDLE);
    }
}
