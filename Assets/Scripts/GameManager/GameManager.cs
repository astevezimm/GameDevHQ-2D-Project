using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameStart;
    public static event Action OnGameStop;

    private readonly StateMachine _stateMachine = new StateMachine();

    public static bool Playing => StateMachine.CurrentState.GetType() == typeof(PlayingState);

    private void Awake()
    {
        MainMenuState mainMenuState = new MainMenuState();
        mainMenuState.OnGameStart += () => OnGameStart?.Invoke();
            
        PlayingState playingState = new PlayingState();
        PauseState pauseState = new PauseState();
        
        PlayerDeathState playerDeathState = new PlayerDeathState();
        playerDeathState.OnPlayerDeath += () => OnGameStop?.Invoke();

        _stateMachine.Set(mainMenuState);
        _stateMachine.AddTransition(
            mainMenuState, playingState, () => MainMenuState.GameStart);
        _stateMachine.AddTransition(
            playingState, pauseState, (() => PauseState.Paused));
        _stateMachine.AddTransition(
            pauseState, playingState, (() => !PauseState.Paused));
        _stateMachine.AddTransition(
            playingState, playerDeathState, () => PlayerDamage.PlayerDead);
    }

    private void Update() => _stateMachine.Tick();

    public void StartGame(InputAction.CallbackContext context)
    {
        if (!ValidateInputContext(context, typeof(MainMenuState)))
            return;
        MainMenuState.StartGame();
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        if (StateMachine.CurrentState.GetType() == typeof(PlayingState))
            PauseState.Paused = true;
        else if (StateMachine.CurrentState.GetType() == typeof(PauseState))
            PauseState.Paused = false;
    }

    private bool ValidateInputContext(InputAction.CallbackContext context, Type type)
    {
        return context.performed && StateMachine.CurrentState.GetType() == type;
    }
}
