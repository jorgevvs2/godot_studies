using DungeonRPG.General.Constants;
using Godot;
using System;

public partial class PlayerDeathState : PlayerState
{
    protected override void EnterState()
    {
        character.AnimPlayer.Play(AnimationConstants.ANIM_DEATH);
        character.AnimPlayer.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        character.QueueFree();
    }
}
