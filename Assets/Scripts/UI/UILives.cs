using UnityEngine;
using UnityEngine.UI;

public class UILives : MonoBehaviour
{
    [SerializeField] private Sprite[] lifeSprites;
    
    private Image _livesImage;

    private void Awake()
    {
        _livesImage = GetComponent<Image>();
        PlayerDamage.OnLivesChanged += HandleLivesChanged;
        GameManager.OnGameStart += () => gameObject.SetActive(true);
        PlayerDeathState.OnMainMenu += () => gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    private void HandleLivesChanged(int lives) => _livesImage.sprite = lifeSprites[lives];
}