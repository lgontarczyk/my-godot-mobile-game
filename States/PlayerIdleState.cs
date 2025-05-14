using Godot;
using MyMobileGame.Scripts;

namespace MyMobileGame.States;

public partial class PlayerIdleState : PlayerState
{
    [Export] private float _deceleration = 8;
    
    public override void Init()
    {
    }

    public override void Enter()
    {
        Player.AnimationPlayer.Play("idle");
        // Direction = Direction with
        // {
        //     X = 1
        // };
    }

    public override void Exit()
    {
    }

    public override PlayerState HandleInput(InputEvent @event)
    {
        return null;
    }

    public override PlayerState PlayerState_PhysicsProcess(double delta)
    {
        Player.UpdateVelocity(0, _deceleration);
        
        if (!Player.IsOnFloor())
            return FallState;
        
        if(Direction.X != 0)
            Player.AnimationPlayer.Play("run");
        
        return null;
    }

    public override PlayerState PlayerState_Process(double delta)
    {
        if (Direction.X != 0)
        {
            return RunState;
        }
        
        return null;
    }
}