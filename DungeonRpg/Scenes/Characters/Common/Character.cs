using DungeonRPG.General.Enums;
using DungeonRPG.Scenes.Characters.Resources;
using Godot;
using System.Linq;

namespace DungeonRPG.Scenes.Common
{
    public partial class Character : CharacterBody3D
    {
        [Export] private StatResource[] stats;


        [ExportGroup("Required")]
        [Export] public AnimationPlayer AnimPlayer { get; set; }
        [Export] public Sprite3D Sprite { get; set; }
        [Export] public StateMachine StateMachine { get; set; }
        [Export] public Area3D HurtBox { get; set; }
        [Export] public Area3D HitBox { get; set; }
        [Export] public CollisionShape3D HitBoxShape { get; set; }



        [ExportGroup("Ai Nodes")]
        [Export] public Path3D Path { get; set; }
        [Export] public NavigationAgent3D Agent { get; set; }
        [Export] public Area3D ChaseArea { get; set; }
        [Export] public Area3D AttackArea { get; set; }

        public Vector2 direction = new();

        public override void _Ready()
        {
            HurtBox.AreaEntered += HurtBoxAreaEntered;
            ToggleHitBox(false);
        }

        private void HurtBoxAreaEntered(Area3D area)
        {
            StatResource health = stats.First(s => s.StatType == Stat.Health);

            Character character = area.GetOwner<Character>();

            health.StatValue -= character.stats.First(s => s.StatType == Stat.Strength).StatValue;

            GD.Print(health.StatValue);
        }

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

        public void ToggleHitBox(bool flag)
        {
            HitBoxShape.Disabled = !flag;
        }
    }
}
