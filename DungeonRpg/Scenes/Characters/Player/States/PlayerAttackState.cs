using DungeonRPG.General.Constants;
using Godot;
using System;

public partial class PlayerAttackState : PlayerState
{
    private int comboCount = 1;
    private int maxComboCount = 2;
    [Export] Timer attackComboTimer;


    protected override void EnterState()
    {

        character.AnimPlayer.Play(
            AnimationConstants.ANIM_ATTACK + comboCount,
            -1, 1.5f
            );

        character.AnimPlayer.AnimationFinished += HandleAnimationFinished;
        attackComboTimer.Timeout += () => comboCount = 1;
    }

    protected override void ExitState()
    {
        character.AnimPlayer.AnimationFinished -= HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        comboCount++;

        comboCount = Mathf.Wrap(
           comboCount, 1, maxComboCount + 1
        );

        attackComboTimer.Start();

        character.StateMachine.SwitchState<PlayerIdleState>();
        character.HitBox.Position = Vector3.Zero;
        character.ToggleHitBox(false);
    }

    private void PerformHit()
    {
        Vector3 newPosition = character.Sprite.FlipH ? 
            Vector3.Left : Vector3.Right;

        newPosition *= 0.75f;

        character.ToggleHitBox(true);
        character.HitBox.Position = newPosition ;
    }
}
