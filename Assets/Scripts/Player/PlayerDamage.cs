using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int lives = 3;

    private static PlayerDamage _instance;

    private void Awake() => _instance = this;

    public static bool PlayerDead => _instance.lives <= 0;

    public void TakeDamage() => lives = Mathf.Max(0, lives - 1);
}
