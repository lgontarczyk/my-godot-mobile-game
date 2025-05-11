using Godot;

namespace MyMobileGame.Scenes;

public partial class Player : CharacterBody2D
{
    private float _gravity;
    private float _moveSpeed = 150;

    private Sprite2D _sprite2D;
    public AnimationPlayer AnimationPlayer;
    private AudioStreamPlayer2D _audioStreamPlayer;
    private PlayerStateMachine _playerStateMachine;
    
    public override void _Ready()
    {
        _sprite2D = GetNode<Sprite2D>("Sprite2D");
        AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _audioStreamPlayer = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
        _playerStateMachine = GetNode<PlayerStateMachine>("PlayerStateMachine");
        
        _playerStateMachine.Init(this);
        
        // _gravity = GetGravity().Y;
        // GD.Print(_gravity);
    }

    public override void _PhysicsProcess(double delta)
    {
        _gravity = GetGravity().Y;
        Velocity = Velocity with
        {
            X = _moveSpeed,
            Y = (float)(Velocity.Y + _gravity * delta)
        };
        
        MoveAndSlide();
    }
}