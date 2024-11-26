using DungeonRPG.General.Constants;
using DungeonRPG.General.Events;
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
        GameEvents.RaiseEndGame();
        character.QueueFree();
    }
}
