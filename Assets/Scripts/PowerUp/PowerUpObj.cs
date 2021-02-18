using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUp")]
public class PowerUpObj : ScriptableObject
{
    private static readonly PowerUpBehaviour TripleShotBehaviour = new TripleShotBehaviour();
    private static readonly PowerUpBehaviour ShieldBehaviour = new ShieldBehaviour();
    
    [SerializeField] private float speed;
    public float Speed => speed;

    [SerializeField] private float coolDown;
    public float CoolDown => coolDown;

    [SerializeField] private PowerUpType type;

    public PowerUpBehaviour Behaviour
    {
        get
        {
            return type switch
            {
                PowerUpType.TripleShot => TripleShotBehaviour,
                PowerUpType.Shield => ShieldBehaviour,
                _ => null
            };
        }
    }

    public string Name => type.ToString();

}