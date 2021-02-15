using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    public event Action<EnemyMovement> OnEnemyLeftScreen;
    
    [SerializeField] private float speed = 5;
    [SerializeField] private float bottom = -6;
    [SerializeField] private float top = 6;
    [SerializeField] private float xSpawnRange = 9.5f;
    
    private Transform _transform;
    
    private void Awake() => _transform = transform;

    private void Update()
    {
        _transform.Translate(Vector2.down * (speed * Time.deltaTime));
        if (_transform.position.y < bottom)
        {
            OnEnemyLeftScreen?.Invoke(this);
            Ready();
        }
    }

    public void Ready()
    {
        _transform.position = new Vector3(RandX(), top);
    }

    private float RandX() => Random.Range(-xSpawnRange, xSpawnRange);
}
