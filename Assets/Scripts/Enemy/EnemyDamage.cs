using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyDamage : MonoBehaviour
{
    public event Action<EnemyDamage> OnEnemyDestroyed;
    
    private Enemy _enemy;

    private void Awake() => _enemy = GetComponent<Enemy>();

    public void TakeDamage()
    {
        OnEnemyDestroyed?.Invoke(this);
        _enemy.Return();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent(out PlayerDamage playerDamage))
            return;
        playerDamage.TakeDamage();
        TakeDamage();
    }
}