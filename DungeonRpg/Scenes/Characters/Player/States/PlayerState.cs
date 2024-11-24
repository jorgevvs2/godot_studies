using DungeonRPG.General.Constants;
using DungeonRPG.Scenes.Common;
using Godot;
using System;

public abstract partial class PlayerState : CharacterState
{
    protected void CheckForAttackInput()
    {
        if(Input.IsActionPressed(MovementConstants.ATTACK))
        {
            character.StateMachine.SwitchState<PlayerAttackState>();
        }
    }
}
