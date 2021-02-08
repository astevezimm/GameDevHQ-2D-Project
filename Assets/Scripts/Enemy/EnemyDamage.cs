using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyDamage : MonoBehaviour
{
    private Enemy _pool;

    private void Awake() => _pool = GetComponent<Enemy>();

    public void TakeDamage() => _pool.Return();

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out PlayerDamage playerDamage))
            return;
        playerDamage.TakeDamage();
        TakeDamage();
    }
}
