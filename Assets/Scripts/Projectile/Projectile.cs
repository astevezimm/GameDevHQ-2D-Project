using UnityEngine;

public class Projectile : PooledObject<Projectile>
{
    [SerializeField] private GameObject singleShot;
    [SerializeField] private GameObject tripleShot;
    [SerializeField] private float speed = 10;
    [SerializeField] private float timeOut = 5;
    [SerializeField] private Vector2 direction = Vector2.up;

    private Transform _transform;
    private float _endTime;

    private GameObject _currentShot;

    private void Awake()
    {
        _transform = transform;
        _currentShot = singleShot;
        tripleShot.SetActive(false);
    }

    private void OnEnable() => _endTime = Time.time + timeOut;

    private void Update()
    {
        _transform.Translate(direction * (speed * Time.deltaTime));
        if (Time.time > _endTime)
            Return();
    }

    public void ActivateTrippleShot()
    {
        singleShot.SetActive(false);
        tripleShot.SetActive(true);
        _currentShot = tripleShot;
    }
    
    public void DeactivateTripleShot()
    {
        singleShot.SetActive(true);
        tripleShot.SetActive(false);
        _currentShot = singleShot;
    }
}