using System;

public class MainMenuState : IState
{
    public event Action OnGameStart;
    
    public static bool GameStart { get; private set; }
    public static void StartGame() => GameStart = true;
    
    public void Tick() { }
    public void OnEnter() { }

    public void OnExit()
    {
        OnGameStart?.Invoke();
        GameStart = false;
    }
}