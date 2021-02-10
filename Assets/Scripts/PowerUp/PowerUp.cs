using UnityEngine;

public class PowerUp : PooledObject<PowerUp>
{
    [SerializeField] private float speed = 3;
    [SerializeField] private float bottom = -6;
    [SerializeField] private float top = 6;
    [SerializeField] private float xSpawnRange = 9.5f;
    
    private Transform _transform;

    private void Awake() => _transform = transform;
    
    private void Update()
    {
        _transform.Translate(Vector2.down * (speed * Time.deltaTime));
        if (_transform.position.y < bottom)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<PlayerFire>().ActivateTripleShot();
        gameObject.SetActive(false);
    }
    
    public void Reset()
    {
        _transform.position = new Vector3(RandX(), top);
    }

    private float RandX() => Random.Range(-xSpawnRange, xSpawnRange);
}