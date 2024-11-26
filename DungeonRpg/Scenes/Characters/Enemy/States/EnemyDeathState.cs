using DungeonRPG.General.Constants;
using DungeonRPG.General.Events;
using DungeonRPG.Scenes.Characters.Enemy;
using Godot;
using System;

public partial class EnemyDeathState : EnemyState
{
    protected override void EnterState()
    {
        character.AnimPlayer.Play(AnimationConstants.ANIM_DEATH);
        character.AnimPlayer.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        character.Path.QueueFree();
    }
}
