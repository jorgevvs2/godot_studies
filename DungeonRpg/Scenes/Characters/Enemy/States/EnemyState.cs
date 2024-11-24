using DungeonRPG.General.Enums;
using DungeonRPG.Scenes.Common;
using Godot;
using System;
using static Godot.WebSocketPeer;

namespace DungeonRPG.Scenes.Characters.Enemy
{
    public abstract partial class EnemyState : CharacterState
    {
        protected Vector3 destination;

        public override void _Ready()
        {
            base._Ready();
            character.GetStatResource(Stat.Health).OnZero += HandleZeroHealth;
        }

        private void HandleZeroHealth()
        {
            character.StateMachine.SwitchState<EnemyDeathState>();
        }

        protected Vector3 GetPointGlobalPosition(int index)
        {
            Vector3 localPos = character.Path.Curve
                        .GetPointPosition(index);
            Vector3 globalPos = character.Path.GlobalPosition;
            return localPos + globalPos;
        }

        protected void Move()
        {
            character.Agent.GetNextPathPosition();
            character.Velocity = character.GlobalPosition
                .DirectionTo(destination);
            character.Velocity = character.Velocity.Normalized() * speed;
            CheckFloor();

            character.MoveAndSlide();
            character.Flip();
        }

        protected void HandleChaseBodyEntered(Node3D body)
        {
            character.StateMachine.SwitchState<EnemyChaseState>();
        }

        protected void HandleAttackBodyEntered(Node3D body)
        {
            character.StateMachine.SwitchState<EnemyAttackState>();
        }

    }
}