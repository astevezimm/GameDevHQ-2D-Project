using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float bottom = -6f;
    
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.down * speed;
    }
    
    /*todo private void Update()
    {
        if at bottom
            Send to top
    }*/
}
