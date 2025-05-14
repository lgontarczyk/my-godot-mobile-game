using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using Godot;
using MyMobileGame.Scripts;

namespace MyMobileGame.Scenes;

[GlobalClass, Icon("res://assets/icon_state_machine_16x16.png")]
public partial class PlayerStateMachine : Node2D
{
    private PlayerState[] _states = [];

    public PlayerState CurrentState => _states[0];
    public PlayerState PreviousState => _states[1];

    public Player Player { get; set; }
    
    public override void _Ready()
    {
        ProcessMode = ProcessModeEnum.Disabled;
    }

    public override void _Process(double delta)
    {
        PlayerState.Direction = new (
            float.Sign(Input.GetAxis("move_left", "move_right")),
            float.Sign(Input.GetAxis("move_up", "move_down"))
            );
        var newState = CurrentState.PlayerState_Process(delta);
        ChangeState(newState);
    }

    public override void _PhysicsProcess(double delta)
    {
        var newState = CurrentState.PlayerState_PhysicsProcess(delta);
        ChangeState(newState);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        var newState = CurrentState.HandleInput(@event);
        ChangeState(newState);
    }

    public void ChangeState(PlayerState newState)
    {
        if (newState == null || newState == CurrentState)
            return;
        
        CurrentState?.Exit();
        _states = _states.Prepend(newState).ToArray();
        newState.Enter();
        _states = _states.Take(3).ToArray();
        GD.Print(string.Join(", ", _states.Select(x => x.GetType().Name)));

    }

    public void Init(Player player)
    {
        Player = player;
        
        _states = GetChildren().OfType<PlayerState>().ToArray();
        
        GD.Print("States found: " + _states.Length);
        
        if(_states.Length == 0)
            return;
        
        PlayerState.Player = player;
        PlayerState.StateMachine = this;

        foreach (var playerState in _states)
        {
            playerState.Init();
        }
        
        //ChangeState(CurrentState);
        
        ChangeState(CurrentState.CrouchState);
        ChangeState(PreviousState.IdleState);
        
        ProcessMode = ProcessModeEnum.Inherit;
    }
}