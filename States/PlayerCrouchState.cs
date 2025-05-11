using Godot;
using MyMobileGame.Scripts;

namespace MyMobileGame.States;

public partial class PlayerCrouchState : PlayerState
{
    public override void Init()
    {
    }

    public override void Enter()
    {
        GD.Print("Entered Crouch state");
        Player.AnimationPlayer.Play("crouch");
    }

    public override void Exit()
    {
        GD.Print("Exited Crouch state");
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