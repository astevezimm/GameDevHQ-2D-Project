using UnityEngine;

public class UIGameOverText : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnGameStop += () => gameObject.SetActive(true);
        PlayerDeathState.OnRestart += () => gameObject.SetActive(false);
        PlayerDeathState.OnMainMenu += () => gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
