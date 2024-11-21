using DungeonRPG.General.Constants;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRPG.Scenes.Common
{
    public partial class Character : CharacterBody3D
    {
        [ExportGroup("Required")]
        [Export] public AnimationPlayer AnimPlayer { get; set; }
        [Export] public Sprite3D Sprite { get; set; }
        [Export] public StateMachine StateMachine { get; set; }

        [ExportGroup("Ai Nodes")]
        [Export] public Path3D Path { get; set; }
        [Export] public NavigationAgent3D Agent { get; set; }

        public Vector2 direction = new();

        public void Flip()
        {
            bool isNotMovingHorizontally = Velocity.X == 0;

            if (isNotMovingHorizontally)
            {
                return;
            }

            bool isMovingLeft = Velocity.X < 0;
            Sprite.FlipH = isMovingLeft;
        }
    }
}
