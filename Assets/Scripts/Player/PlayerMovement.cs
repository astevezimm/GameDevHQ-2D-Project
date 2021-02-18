using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float regularSpeed = 7;
    [SerializeField] private float boostedSpeed = 10;
    [SerializeField] private float minY = -4.5f;
    [SerializeField] private float maxY = 0;
    [SerializeField] private float xRange = 9.5f;
    
    private Transform _transform;
    private float _speed;

    private void Awake()
    {
        _transform = transform;
        _speed = regularSpeed;
        GameManager.OnGameStart += Reset;
        PlayerController.OnSpeedBoostActivate += () => _speed = boostedSpeed;
        PlayerController.OnSpeedBoostDeactivate += () => _speed = regularSpeed;
    }

    private void Update()
    {
        _transform.Translate(PlayerController.Movement * (_speed * Time.deltaTime));
        _transform.position = new Vector3(WrapX(), ClampY());
    }

    private void Reset() => _transform.position = Vector3.zero;
    
    private float WrapX()
    {
        float x = _transform.position.x;
        if (x < -xRange || x > xRange)
            return -x;
        return x;
    }

    private float ClampY() => Mathf.Clamp(_transform.position.y, minY, maxY);
}
