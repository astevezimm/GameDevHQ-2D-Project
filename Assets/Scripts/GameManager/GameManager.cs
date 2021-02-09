using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    
    private StateMachine _stateMachine = new StateMachine();

    private void Awake()
    {
        PlayingState playingState = new PlayingState();
        PlayerDeathState playerDeathState = new PlayerDeathState();
        playerDeathState.OnPlayerDeath += HandlePlayerDeath;

        _stateMachine.Set(playingState);
        
        _stateMachine.AddTransition(
            playingState, playerDeathState, () => PlayerDamage.PlayerDead);
    }

    private void Update() => _stateMachine.Tick();

    private void HandlePlayerDeath() => OnPlayerDeath?.Invoke();
}
