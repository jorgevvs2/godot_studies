using DungeonRPG.General.Constants;
using Godot;

public abstract partial class PlayerState : Node
{
    protected Player character;

    public override void _Ready()
    {
        character = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
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
