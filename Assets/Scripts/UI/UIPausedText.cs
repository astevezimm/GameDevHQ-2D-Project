using UnityEngine;

public class UIPausedText : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
        PauseState.OnPause += () => gameObject.SetActive(true);
        PauseState.OnUnpause += () => gameObject.SetActive(false);
    }
}
