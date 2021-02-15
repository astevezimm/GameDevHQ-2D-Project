using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public static event Action OnGameStart;
    
    private readonly StateMachine _stateMachine = new StateMachine();

    public static bool Playing => StateMachine.CurrentState.GetType() == typeof(PlayingState);

    private void Awake()
    {
        MainMenuState mainMenuState = new MainMenuState();
        mainMenuState.OnGameStart += HandleGameStart;
            
        PlayingState playingState = new PlayingState();
        PauseState pauseState = new PauseState();
        
        PlayerDeathState playerDeathState = new PlayerDeathState();
        playerDeathState.OnPlayerDeath += HandlePlayerDeath;

        _stateMachine.Set(mainMenuState);
        _stateMachine.AddTransition(
            mainMenuState, playingState, () => MainMenuState.GameStart);
        _stateMachine.AddTransition(
            playingState, playerDeathState, () => PlayerDamage.PlayerDead);
    }

    private void Update() => _stateMachine.Tick();

    private void HandlePlayerDeath() => OnPlayerDeath?.Invoke();
    private void HandleGameStart() => OnGameStart?.Invoke();

    public void StartGame(InputAction.CallbackContext context)
    {
        if (!ValidateInputContext(context, typeof(MainMenuState)))
            return;
        MainMenuState.StartGame();
    }

    private bool ValidateInputContext(InputAction.CallbackContext context, Type type)
    {
        return context.performed && StateMachine.CurrentState.GetType() == type;
    }
}
