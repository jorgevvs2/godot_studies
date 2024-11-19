using DungeonRPG.General.Constants;
using Godot;

public partial class MoveState : PlayerState
{
    [Export(PropertyHint.Range, "0,20,0.1")] private float speed = 5;
    public override void _PhysicsProcess(double delta)
    {
        if (character.direction == Vector2.Zero && !Input.IsActionPressed("Dash"))
        {
            character.StateMachine.SwitchState<IdleState>();
            return;
        }
        character.Velocity = new(character.direction.X, 0, character.direction.Y);
        character.Velocity *= speed;

        character.MoveAndSlide();
        character.Flip();
    }

    protected override void EnterState()
    {
        character.AnimPlayer.Play(GameConstants.ANIM_MOVE);
    }
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionPressed(MovementConstants.DASH))
        {
            character.StateMachine.SwitchState<DashState>();
        }
    }
}
