using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : PooledObject<Projectile>
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float timeOut = 5;
    [SerializeField] private Vector3 direction = Vector3.up;
    
    private Rigidbody _rigidbody;
    private float _endTime;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = direction * speed;
    }

    private void OnEnable() => _endTime = Time.time + timeOut;

    private void Update()
    {
        if (Time.time  > _endTime)
            Return();
    }

    private void OnTriggerEnter(Collider other) => Return();
}