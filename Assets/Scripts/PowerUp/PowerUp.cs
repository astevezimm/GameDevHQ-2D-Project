using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    [SerializeField] private float bottom = -6;
    
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
}