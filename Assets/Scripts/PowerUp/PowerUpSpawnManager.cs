using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnManager : MonoBehaviour
{
    [SerializeField] private PowerUp powerUpPrefab;
    [SerializeField] private float minInterval = 3;
    [SerializeField] private float maxInterval = 7;
    [SerializeField] private List<PowerUpObj> powerUps;

    private WaitUntil _waitUntilRandomInterval;
    private WaitUntil _waitUntilGameStart;
    private float _nextSpawnTime = 7;

    private void Start()
    {
        _waitUntilRandomInterval = new WaitUntil(RandomInterval);
        _waitUntilGameStart = new WaitUntil(() => GameManager.Playing);
        Coroutine spawn = StartCoroutine(Spawn());
        GameManager.OnPlayerDeath += () => StopCoroutine(spawn);
        //todo GameManager.OnRestart startcoroutine
    }

    private IEnumerator Spawn()
    {
        yield return _waitUntilGameStart;
        while (true)
        {
            yield return _waitUntilRandomInterval;
            PowerUp powerUp = powerUpPrefab.Get();
            powerUp.Ready(powerUps[Random.Range(0, powerUps.Count)]);
        }
    }

    private bool RandomInterval()
    {
        if (Time.time < _nextSpawnTime)
            return false;
        _nextSpawnTime += Random.Range(minInterval, maxInterval);
        return true;
    }
}