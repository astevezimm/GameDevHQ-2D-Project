using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnManager : MonoBehaviour
{
    [SerializeField] private PowerUp powerUpPrefab;
    [SerializeField] private float minInterval = 3;
    [SerializeField] private float maxInterval = 7;
    [SerializeField] private List<PowerUpObj> powerUps;

    private WaitUntil _waitUntil;
    private float _nextSpawnTime = 7;

    private void Start()
    {
        _waitUntil = new WaitUntil(RandomInterval);
        Coroutine spawn = StartCoroutine(Spawn());
        GameManager.OnPlayerDeath += () => StopCoroutine(spawn);
        //todo GameManager.OnRestart startcoroutine
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return _waitUntil;
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