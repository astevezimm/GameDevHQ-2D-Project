using System.Collections;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Projectile laserPrefab;
    [SerializeField] private Transform source;
    [SerializeField] private float coolDown = 0.15f;
    [SerializeField] private float tripleShotCoolDown = 5;

    private float _nextFire = -1;
    private bool _tripleShotActive = false;
    private WaitForSeconds _tripleShotCoolDownWait;
    
    private void Awake()
    {
        Input.OnFire += HandleFire;
        _tripleShotCoolDownWait = new WaitForSeconds(tripleShotCoolDown);
    }

    private void HandleFire()
    {
        if (Time.time < _nextFire)
            return;
        Projectile laser = laserPrefab.Get(source);
        if (_tripleShotActive)
            laser.ActivateTrippleShot();
        else
            laser.DeactivateTripleShot();
        _nextFire = Time.time + coolDown;
    }

    public void ActivateTripleShot()
    {
        _tripleShotActive = true;
        StartCoroutine(TripleShotCoolDown());
    }

    private IEnumerator TripleShotCoolDown()
    {
        yield return _tripleShotCoolDownWait;
        _tripleShotActive = false;
    }
}