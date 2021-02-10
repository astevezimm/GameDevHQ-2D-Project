using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    private Projectile _projectile;

    private void Awake()
    {
        _projectile = GetComponent<Projectile>();
        if (_projectile == null)
            _projectile = transform.parent.GetComponent<Projectile>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<EnemyDamage>()?.TakeDamage();
        _projectile.Return();
    }
}