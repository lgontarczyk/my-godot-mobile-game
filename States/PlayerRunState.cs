using Godot;
using MyMobileGame.Scripts;

namespace MyMobileGame.States;

public partial class PlayerRunState : PlayerState
{
    [Export(PropertyHint.None, "suffix:px/s")]
    private float _speed = 100;
    
    [Export(PropertyHint.None, "suffix:px/s")]
    private float _sprintSpeed = 150;

    [Export] private float _acceleration = 4;
    [Export] private float _skidAcceleration = 8;
    [Export] private AudioStream _skidAudio;

    private float _currentAcceleration;
    private float _currentDirection;
    private float _targetSpeed;
    
    public override void Init()
    {
    }

    public override void Enter()
    {
        Player.AnimationPlayer.Play("run");
        _currentAcceleration = _acceleration;
        _targetSpeed = _speed;
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
        GD.Print(delta);
        
        if (!Player.IsOnFloor())
            return FallState;
        
        if (Direction.X == 0)
            return IdleState;

        if (float.Sign(Direction.X) == float.Sign(Player.Velocity.X) || Player.Velocity.X == 0)
        {
            _currentAcceleration = _acceleration;
            Player.AnimationPlayer.Play("run");
        }
        else
        {
            _currentAcceleration = _skidAcceleration;
            Player.AnimationPlayer.Play("skid");
        }

        Player.UpdateVelocity(Direction.X * _speed, _currentAcceleration);

        return null;
    }

    public override PlayerState PlayerState_Process(double delta)
    {
        return null;
    }
}