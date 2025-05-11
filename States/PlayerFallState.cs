using Godot;
using MyMobileGame.Scripts;

namespace MyMobileGame.States;

public partial class PlayerFallState : PlayerState
{
    public override void Init()
    {
    }

    public override void Enter()
    {
        GD.Print("Entered Fall state");
        Player.AnimationPlayer.Play("fall");
    }

    public override void Exit()
    {
        GD.Print("Exited Fall state");
    }

    public override PlayerState HandleInput(InputEvent @event)
    {
        return null;
    }

    public override PlayerState PlayerState_PhysicsProcess(double delta)
    {
        if (Player.IsOnFloor())
            return IdleState;
        
        return null;
    }

    public override PlayerState PlayerState_Process(double delta)
    {
        return null;
    }
}