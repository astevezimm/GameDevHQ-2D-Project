using System;

public class PlayerDeathState : IState
{
    public event Action OnPlayerDeath;
    
    public static event Action OnRestart;
    public static event Action OnMainMenu;
    
    public static bool RestartFlag { get; private set; }
    public static bool MainMenuFlag { get; private set; }

    public static void Restart() => RestartFlag = true;

    public static void MainMenu() => MainMenuFlag = true;

    public void Tick() { }
    public void OnEnter() => OnPlayerDeath.Invoke();
    public void OnExit()
    {
        if (RestartFlag)
        {
            OnRestart?.Invoke();
            RestartFlag = false;
        }
        else
        {
            OnMainMenu?.Invoke();
            MainMenuFlag = false;
        }
    }
}