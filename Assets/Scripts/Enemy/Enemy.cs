public class Enemy : PooledObject<Enemy>
{
    public EnemyMovement Movement { get; private set; }

    private void Awake() => Movement = GetComponent<EnemyMovement>();

    private void OnEnable() => GameManager.OnGameStart += HandleGameStart;
    private void OnDisable() => GameManager.OnGameStart -= HandleGameStart;

    private void HandleGameStart() => Return();
}