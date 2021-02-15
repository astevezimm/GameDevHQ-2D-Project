using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnGameStart += HandleGameStart;
    }

    private void HandleGameStart() => gameObject.SetActive(false);
}
