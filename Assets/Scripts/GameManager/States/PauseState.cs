using System;
using UnityEngine;

public class PauseState : IState
{
    public static event Action OnPause;
    public static event Action OnUnpause;
    
    public static bool Paused { get; set; }
    
    public void Tick() { }
    public void OnEnter()
    {
        Time.timeScale = 0;
        OnPause?.Invoke();
    }

    public void OnExit()
    {
        Time.timeScale = 1;
        OnUnpause?.Invoke();
    }
}