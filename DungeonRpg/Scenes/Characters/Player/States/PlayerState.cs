using DungeonRPG.General.Constants;
using DungeonRPG.General.Enums;
using DungeonRPG.Scenes.Common;
using Godot;
using System;

public abstract partial class PlayerState : CharacterState
{
    public override void _Ready()
    {
        base._Ready();
        character.GetStatResource(Stat.Health).OnZero += HandleZeroHealth;
    }

    private void HandleZeroHealth()
    {
        character.StateMachine.SwitchState<PlayerDeathState>();
    }

    protected void CheckForAttackInput()
    {
        if(Input.IsActionPressed(MovementConstants.ATTACK))
        {
            character.StateMachine.SwitchState<PlayerAttackState>();
        }
    }
}
