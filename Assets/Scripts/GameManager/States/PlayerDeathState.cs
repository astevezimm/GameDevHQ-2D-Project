using System;

public class PlayerDeathState : IState
{
    public event Action OnPlayerDeath;
    
    public void Tick() { }
    public void OnEnter() => OnPlayerDeath.Invoke();
    public void OnExit() { }
}