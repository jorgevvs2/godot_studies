using DungeonRPG.General.Constants;
using Godot;

public partial class DashState : PlayerState
{
    [Export] private Timer dashTimer = new();
    [Export(PropertyHint.Range,"0,20,0.1")] private float speed = 10;
    public override void _Ready()
    {
        base._Ready();
        dashTimer.Timeout += handleDashTimeout;
    }

    private void handleDashTimeout()
    {
        character.Velocity = Vector3.Zero;
        character.StateMachine.SwitchState<IdleState>();
    }

    public override void _PhysicsProcess(double delta)
    {
        character.MoveAndSlide();
        character.Flip();
    }

    protected override void EnterState()
    {
        character.AnimPlayer.Play(GameConstants.ANIM_DASH);
        character.Velocity = new(character.direction.X, 0, character.direction.Y);
        if (character.Velocity == Vector3.Zero)
        {
            character.Velocity = character.Sprite.FlipH ?
                Vector3.Left : Vector3.Right;
        }
        character.Velocity *= speed;
        dashTimer.Start();
    }
}
