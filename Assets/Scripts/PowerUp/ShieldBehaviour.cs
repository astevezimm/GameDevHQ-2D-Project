using UnityEngine;

public class ShieldBehaviour : PowerUpBehaviour
{
    private PlayerDamage _playerDamage;
    
    public static float CoolDown { get; private set; }

    public new void Activate(Collider2D player, float coolDown)
    {
        base.Activate(player, coolDown);
        CoolDown = coolDown;
    }
    
    protected override void Activate(Collider2D player)
    {
        _playerDamage = player.GetComponent<PlayerDamage>();
        _playerDamage.ActivateShield();
    }

    protected override void Deactivate() => _playerDamage.DeactivateShield();
}