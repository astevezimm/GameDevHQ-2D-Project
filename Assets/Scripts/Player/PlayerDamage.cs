using System;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public static event Action<int> OnLivesChanged;
    public event Action<bool> OnShieldChanged;

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
        OnLivesChanged?.Invoke(lives);
    }

    public void ActivateShield()
    {
        _shield = true;
        OnShieldChanged?.Invoke(true);
    }

    public void DeactivateShield()
    {
        _shield = false;
        OnShieldChanged?.Invoke(false);
    }
}