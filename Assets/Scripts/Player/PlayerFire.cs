using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Projectile laserPrefab;
    [SerializeField] private Transform source;
    [SerializeField] private float coolDown = 0.15f;

    private float _nextFire = -1;
    private bool _tripleShotActive = false;
    
    private void Awake()
    {
        PlayerController.OnFire += HandleFire;
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

    public void ActivateTripleShot() => _tripleShotActive = true;

    public void DeactivateTripleShot() => _tripleShotActive = false;
}