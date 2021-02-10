using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Projectile laserPrefab;
    [SerializeField] private TripleShot tripleShotPrefab;
    [SerializeField] private Transform source;
    [SerializeField] private float coolDown = 0.15f;

    private float _nextFire = -1;
    private bool _tripleShotActive = false;
    
    private void Awake() => Input.OnFire += HandleFire;

    private void HandleFire()
    {
        if (Time.time < _nextFire)
            return;
        if (_tripleShotActive)
            tripleShotPrefab.Get(source);
        else
            laserPrefab.Get(source);
        _nextFire = Time.time + coolDown;
    }
}