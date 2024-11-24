using DungeonRPG.General.Constants;
using DungeonRPG.Scenes.Characters.Enemy;
using DungeonRPG.Scenes.Common;
using Godot;
using System;

public partial class EnemyReturnState : EnemyState
{
    public override void _Ready()
    {
        base._Ready();

        destination = GetPointGlobalPosition(0);
    }

    protected override void EnterState()
    {
        character.AnimPlayer.Play(AnimationConstants.ANIM_MOVE);

        character.Agent.TargetPosition = destination;
        character.ChaseArea.BodyEntered += HandleChaseBodyEntered;
    }
    protected override void ExitState()
    {
        character.ChaseArea.BodyEntered -= HandleChaseBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (character.Agent.IsNavigationFinished())
        {
            character.StateMachine.SwitchState<EnemyPatrolState>();
            return;
        }

        Move();
    }
}

