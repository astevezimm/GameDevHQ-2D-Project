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
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            if (true /*check for player death*/)
            {
                Enemy enemy = enemyPrefab.Get();
                enemy.Movement.Reset();
            }
            yield return _waitForSeconds;
        }
    }
}