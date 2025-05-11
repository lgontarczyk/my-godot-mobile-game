using Godot;
using MyMobileGame.Scripts;

namespace MyMobileGame.States;

public partial class PlayerJumpState : PlayerState
{
    public override void Init()
    {
    }

    public override void Enter()
    {
        GD.Print("Entered Jump state");
        Player.AnimationPlayer.Play("jump");
    }

    public override void Exit()
    {
        GD.Print("Exited Jump state");
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