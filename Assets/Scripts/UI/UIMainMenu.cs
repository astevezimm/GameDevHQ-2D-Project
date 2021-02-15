using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnGameStart += () => gameObject.SetActive(false);
        PlayerDeathState.OnMainMenu += () => gameObject.SetActive(true);
    }
}
