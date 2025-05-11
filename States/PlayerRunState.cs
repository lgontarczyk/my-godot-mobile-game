using Godot;
using MyMobileGame.Scripts;

namespace MyMobileGame.States;

public partial class PlayerRunState : PlayerState
{
    public override void Init()
    {
    }

    public override void Enter()
    {
        GD.Print("Entered Run state");
        Player.AnimationPlayer.Play("run");
    }

    public override void Exit()
    {
        GD.Print("Exited Run state");
    }

    public override PlayerState HandleInput(InputEvent @event)
    {
        return null;
    }

    public override PlayerState PlayerState_PhysicsProcess(double delta)
    {
        return null;
    }

    public override PlayerState PlayerState_Process(double delta)
    {
        return null;
    }
}