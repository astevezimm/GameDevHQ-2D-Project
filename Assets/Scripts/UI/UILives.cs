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
    }

    private void HandleLivesChanged(int lives) => _livesImage.sprite = lifeSprites[lives];
}