using UnityEngine;

public class Projectile : PooledObject<Projectile>
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float timeOut = 5;
    [SerializeField] private Vector2 direction = Vector2.up;

    private Transform _transform;
    private float _endTime;

    private void Awake() => _transform = transform;

    private void OnEnable() => _endTime = Time.time + timeOut;

    private void Update()
    {
        _transform.Translate(direction * (speed * Time.deltaTime));
        if (Time.time  > _endTime)
            Return();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<EnemyDamage>()?.TakeDamage();
        Return();
    }
}