using DungeonRPG.General.Constants;
using DungeonRPG.Scenes.Characters.Enemy;
using DungeonRPG.Scenes.Common;
using Godot;
using System;
public partial class EnemyPatrolState : EnemyState
{
    [Export] private Timer idleTimer;
    [Export(PropertyHint.Range, "0,20,0.1")]
    private float maxIdleTime = 4;

    private int pointIndex = 0;

    protected override void EnterState()
    {
        character.AnimPlayer.Play(AnimationConstants.ANIM_MOVE);

        pointIndex = 1;

        destination = GetPointGlobalPosition(pointIndex);
        character.Agent.TargetPosition = destination;

        character.Agent.NavigationFinished += HandleNavigationFinished;
        idleTimer.Timeout += HandleTimeout;
        character.ChaseArea.BodyEntered += HandleChaseBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!idleTimer.IsStopped())
        {
            return;
        }

        Move();
    }

    private void HandleNavigationFinished()
    {
        character.AnimPlayer.Play(AnimationConstants.ANIM_IDLE);

        RandomNumberGenerator rng = new();
        idleTimer.WaitTime = rng.RandfRange(0, maxIdleTime);

        idleTimer.Start();
    }

    protected override void ExitState()
    {

        character.Agent.NavigationFinished -= HandleNavigationFinished;
        idleTimer.Timeout -= HandleTimeout;
        character.ChaseArea.BodyEntered -= HandleChaseBodyEntered;
    }

    private void HandleTimeout()
    {
        character.AnimPlayer.Play(AnimationConstants.ANIM_MOVE); 

        pointIndex = Mathf.Wrap(
           pointIndex + 1, 0, character.Path.Curve.PointCount
       );

        destination = GetPointGlobalPosition(pointIndex);
        character.Agent.TargetPosition = destination;
    }
}

