using UnityEngine;

public class PowerUp : PooledObject<PowerUp>
{
    [SerializeField] private float bottom = -6;
    [SerializeField] private float top = 6;
    [SerializeField] private float xSpawnRange = 9.5f;
    
    private Transform _transform;
    private PowerUpObj _specs;
    private Animator _animator;

    private void Awake()
    {
        _transform = transform;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _transform.Translate(Vector3.down * (_specs.Speed * Time.deltaTime));
        if (_transform.position.y < bottom)
            Return();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _specs.Behaviour.Activate(other, _specs.CoolDown);
        Return();
    }
    
    public void Ready(PowerUpObj specs)
    {
        _specs = specs;
        _transform.position = new Vector3(RandX(), top);
        _animator.SetTrigger(_specs.Name);
    }

    private float RandX() => Random.Range(-xSpawnRange, xSpawnRange);
}