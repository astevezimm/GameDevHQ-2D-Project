using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float explosionWait = 2.5f;
    
    public event Action<EnemyDamage> OnEnemyDestroyed;
    
    private Enemy _enemy;
    private WaitForSeconds _delayedReturn;
    private bool _exploding;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _delayedReturn = new WaitForSeconds(explosionWait);
    }

    public void TakeDamage()
    {
        OnEnemyDestroyed?.Invoke(this);
        StartCoroutine(DelayedReturn());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_exploding || !other.TryGetComponent(out PlayerDamage playerDamage))
            return;
        playerDamage.TakeDamage();
        TakeDamage();
    }

    private IEnumerator DelayedReturn()
    {
        _exploding = true;
        yield return _delayedReturn;
        _exploding = false;
        _enemy.Return();
    }
}