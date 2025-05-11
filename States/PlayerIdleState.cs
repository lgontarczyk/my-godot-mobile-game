using Godot;
using MyMobileGame.Scripts;

namespace MyMobileGame.States;

public partial class PlayerIdleState : PlayerState
{
    public override void Init()
    {
    }

    public override void Enter()
    {
        GD.Print("Entered idle state");
        Player.AnimationPlayer.Play("idle");
        Direction = Direction with
        {
            X = 1
        };
    }

    public override void Exit()
    {
        GD.Print("Exited idle state");
    }

    public override PlayerState HandleInput(InputEvent @event)
    {
        return null;
    }

    public override PlayerState PlayerState_PhysicsProcess(double delta)
    {
        if (!Player.IsOnFloor())
            return FallState;
        
        if(Direction.X != 0)
            Player.AnimationPlayer.Play("run");
        
        return null;
    }

    public override PlayerState PlayerState_Process(double delta)
    {
        return null;
    }
}