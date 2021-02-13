using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int lives = 3;

    private static PlayerDamage _instance;

    private bool _shield = false;

    private void Awake() => _instance = this;

    public static bool PlayerDead => _instance.lives <= 0;

    public void TakeDamage()
    {
        if (_shield)
            return;
        lives = Mathf.Max(0, lives - 1);
    }

    public void ActivateShield() => _shield = true;

    public void DeactivateShield() => _shield = false;
}
