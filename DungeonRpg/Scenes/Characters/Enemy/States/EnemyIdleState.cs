using DungeonRPG.General.Constants;
using DungeonRPG.Scenes.Characters.Enemy;
using DungeonRPG.Scenes.Common;
using Godot;
using System;

public partial class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        character.AnimPlayer.Play(AnimationConstants.ANIM_IDLE);
        character.ChaseArea.BodyEntered += HandleChaseBodyEntered;
    }
    protected override void ExitState()
    {
        character.ChaseArea.BodyEntered -= HandleChaseBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);
        character.StateMachine.SwitchState<EnemyReturnState>();
    }
}

