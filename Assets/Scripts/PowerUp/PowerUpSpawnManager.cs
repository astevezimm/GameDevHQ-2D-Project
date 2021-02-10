using System.Collections;
using UnityEngine;

public class PowerUpSpawnManager : MonoBehaviour
{
    [SerializeField] private PowerUp powerUpPrefab;
    [SerializeField] private float interval = 7;

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
            yield return _waitForSeconds;
            PowerUp powerUp = powerUpPrefab.Get();
            powerUp.Reset();
        }
    }
}