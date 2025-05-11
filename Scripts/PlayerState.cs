using Godot;
using MyMobileGame.Scenes;
using MyMobileGame.States;

namespace MyMobileGame.Scripts;

public abstract partial class PlayerState : Node2D
{
    public static Player Player { get; set; }
    public static PlayerStateMachine StateMachine { get; set; }
    public static Vector2 Direction { get; set; }


    public PlayerIdleState IdleState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerCrouchState CrouchState { get; private set; }
    
    public override void _Ready()
    {
        IdleState = GetNode<PlayerIdleState>("%Idle");
        RunState = GetNode<PlayerRunState>("%Run");
        JumpState = GetNode<PlayerJumpState>("%Jump");
        FallState = GetNode<PlayerFallState>("%Fall");
        CrouchState = GetNode<PlayerCrouchState>("%Crouch");
    }

    public abstract void Init();
    public abstract void Enter();
    public abstract void Exit();
    public abstract PlayerState HandleInput(InputEvent @event);

    public abstract PlayerState PlayerState_PhysicsProcess(double delta);

    public abstract PlayerState PlayerState_Process(double delta);
}