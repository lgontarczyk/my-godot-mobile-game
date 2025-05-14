using Godot;

namespace MyMobileGame.Scenes;

public partial class Player : CharacterBody2D
{
    private float _gravity;
    private float _moveSpeed = 150;

    private Sprite2D _sprite2D;
    private AudioStreamPlayer2D _audioStreamPlayer;
    private PlayerStateMachine _playerStateMachine;
    
    public AnimationPlayer AnimationPlayer { get; private set; }
    
    public override void _Ready()
    {
        _sprite2D = GetNode<Sprite2D>("Sprite2D");
        _audioStreamPlayer = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        _playerStateMachine = GetNode<PlayerStateMachine>("PlayerStateMachine");
        
        AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        
        _playerStateMachine.Init(this);
    }

    public override void _PhysicsProcess(double delta)
    {
        _gravity = GetGravity().Y;
        Velocity = Velocity with
        {
           // X = _moveSpeed,
            Y = (float)(Velocity.Y + _gravity * delta)
        };
        
        MoveAndSlide();
    }

    internal void UpdateVelocity(float velocity, float acceleration)
    {
        Velocity = Velocity with
        {
            X = Mathf.MoveToward(Velocity.X, velocity, acceleration)
        };
    }
    
    
}