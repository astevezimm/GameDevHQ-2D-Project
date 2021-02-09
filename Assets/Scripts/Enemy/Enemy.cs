public class Enemy : PooledObject<Enemy>
{
    public EnemyMovement Movement { get; private set; }

    private void Awake() => Movement = GetComponent<EnemyMovement>();
}