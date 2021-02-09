using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float bottom = -6;
    [SerializeField] private float top = 6;
    [SerializeField] private float xSpawnRange = 9.5f;
    
    private Rigidbody _rigidbody;
    private Transform _transform;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.down * speed;
        _transform = transform;
    }
    
    private void Update()
    {
        if (_transform.position.y < bottom)
            Reset();
    }

    public void Reset()
    {
        _transform.position = new Vector3(RandX(), top);
    }

    private float RandX() => Random.Range(-xSpawnRange, xSpawnRange);
}
