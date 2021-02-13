using System.Collections;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float interval = 5;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(interval);
        Coroutine spawn = StartCoroutine(Spawn());
        GameManager.OnPlayerDeath += () => StopCoroutine(spawn);
        //todo GameManager.OnRestart startcoroutine
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Enemy enemy = enemyPrefab.Get();
            enemy.Movement.Ready();
            yield return _waitForSeconds;
        }
    }
}