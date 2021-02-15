using System;
using System.Collections;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public static event Action OnEnemyDestroyed;
    public static event Action OnEnemyLeftScreen;
    
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float interval = 5;

    private WaitForSeconds _waitForSeconds;
    private WaitUntil _waitUntilGamePlaying;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(interval);
        _waitUntilGamePlaying = new WaitUntil(() => GameManager.Playing);
        Coroutine spawn = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return _waitUntilGamePlaying;
            Enemy enemy = enemyPrefab.Get();
            enemy.Movement.Ready();
            enemy.GetComponent<EnemyDamage>().OnEnemyDestroyed += HandleEnemyDestroyed;
            enemy.GetComponent<EnemyMovement>().OnEnemyLeftScreen += HandleEnemyLeftScreen;
            yield return _waitForSeconds;
        }
    }

    private void HandleEnemyDestroyed(EnemyDamage enemy)
    {
        enemy.OnEnemyDestroyed -= HandleEnemyDestroyed;
        OnEnemyDestroyed?.Invoke();
    }

    private void HandleEnemyLeftScreen(EnemyMovement enemy)
    {
        enemy.OnEnemyLeftScreen -= HandleEnemyLeftScreen;
        OnEnemyLeftScreen?.Invoke();
    }
}