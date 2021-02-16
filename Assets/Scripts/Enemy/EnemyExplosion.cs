using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    private Animator _animator;
    private readonly int _explode = Animator.StringToHash("Explode");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        GetComponent<EnemyDamage>().OnEnemyDestroyed += HandleEnemyDestroyed;
    }

    private void HandleEnemyDestroyed(EnemyDamage obj) => _animator.SetTrigger(_explode);
}