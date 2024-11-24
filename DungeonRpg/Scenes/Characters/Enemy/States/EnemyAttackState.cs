using DungeonRPG.General.Constants;
using DungeonRPG.Scenes.Characters.Enemy;
using Godot;
using System;
using System.Linq;

public partial class EnemyAttackState : EnemyState
{
    private Vector3 targetPosition;
    Node3D target;
    protected override void EnterState()
    {
        character.AnimPlayer.AnimationFinished += HandleAnimationFinished;
        Attack();
    }

    protected override void ExitState()
    {
        character.AnimPlayer.AnimationFinished -= HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        Attack();
    }

    private void Attack()
    {
        target = character.AttackArea.GetOverlappingBodies().FirstOrDefault();

        if (target == null)
        {
            Node3D body = character.ChaseArea.GetOverlappingBodies().FirstOrDefault();

            if(body != null)
            {
                character.StateMachine.SwitchState<EnemyChaseState>();
                return;
            }

            character.ToggleHitBox(false);

            character.StateMachine.SwitchState<EnemyChaseState>();
            return;
        }

        targetPosition = target.GlobalPosition;
        if (targetPosition.X < character.GlobalPosition.X)
        {
            character.Sprite.FlipH = true;
        }
        else
        {
            character.Sprite.FlipH = false;
        }


        character.AnimPlayer.Play(AnimationConstants.ANIM_ATTACK);

    }

    private void PerformHit()
    {
        character.ToggleHitBox(true);
        character.HitBox.GlobalPosition = targetPosition;
    }
}
