using DungeonRPG.General.Constants;
using DungeonRPG.Scenes.Characters.Enemy;
using Godot;
using System;
using System.Linq;

public partial class EnemyChaseState : EnemyState
{
    private CharacterBody3D target;
    [Export] private Timer updateChaseTimer;
    protected override void EnterState()
    {
        character.AnimPlayer.Play(AnimationConstants.ANIM_MOVE);

        updateChaseTimer.Start();

        target = character.ChaseArea.GetOverlappingBodies().First() as CharacterBody3D;
        updateChaseTimer.Timeout += UpdateChaseDestination;
        character.AttackArea.BodyEntered += HandleAttackBodyEntered;
        character.ChaseArea.BodyExited += HandleChaseBodyExited;
    }

    private void HandleChaseBodyExited(Node3D body)
    {
        character.StateMachine.SwitchState<EnemyReturnState>();
    }

    protected override void ExitState()
    {
        updateChaseTimer.Stop();
        updateChaseTimer.Timeout -= UpdateChaseDestination;
        character.AttackArea.BodyEntered -= HandleAttackBodyEntered;
        character.ChaseArea.BodyExited -= HandleChaseBodyExited;
    }

    private void UpdateChaseDestination()
    {
        destination = target.GlobalPosition;
        character.Agent.TargetPosition = destination;
    }

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }
}
