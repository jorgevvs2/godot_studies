using DungeonRPG.General.Constants;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRPG.Scenes.Common
{
    public abstract partial class CharacterState : Node
    {
        [Export(PropertyHint.Range, "0,20,0.1")] protected float speed = 5;

        protected Character character;

        public override void _Ready()
        {
            character = GetOwner<Character>();
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
        protected void CheckFloor()
        {
            if (!character.IsOnFloor())
            {
                Vector3 velocity = character.Velocity;
                velocity.Y -= 9.8f;
                character.Velocity = velocity;
            }
        }

        public override void _Notification(int what)
        {
            base._Notification(what);
            if (what == NotificationConstants.ENTER_STATE)
            {
                EnterState();
                SetPhysicsProcess(true);
                SetProcessInput(true);
            }
            else if (what == NotificationConstants.EXIT_STATE)
            {
                SetPhysicsProcess(false);
                SetProcessInput(false);
            }
        }
        protected virtual void EnterState() { }

    }
}
