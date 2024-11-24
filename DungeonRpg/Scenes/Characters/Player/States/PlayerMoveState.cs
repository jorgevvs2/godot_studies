using DungeonRPG.General.Constants;
using Godot;

public partial class PlayerMoveState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        if (character.direction == Vector2.Zero && !Input.IsActionPressed("Dash"))
        {
            character.StateMachine.SwitchState<PlayerIdleState>();
            return;
        }
        character.Velocity = new(character.direction.X, 0, character.direction.Y);
        character.Velocity *= speed;

        CheckFloor();

        character.MoveAndSlide();
        character.Flip();
    }

    protected override void EnterState()
    {
        character.AnimPlayer.Play(AnimationConstants.ANIM_MOVE);
    }
    public override void _Input(InputEvent @event)
    {
        CheckForAttackInput();
        if (Input.IsActionPressed(MovementConstants.DASH))
        {
            character.StateMachine.SwitchState<PlayerDashState>();
        }
    }
}
