using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : PooledObject<Projectile>
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float timeOut = 5;
    
    private Rigidbody _rigidbody;
    private float _endTime;
    
    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.up * speed;
        _endTime = Time.time + timeOut;
    }

    private void Update()
    {
        if (Time.time  > _endTime)
            Return();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Return();
    }
    
}