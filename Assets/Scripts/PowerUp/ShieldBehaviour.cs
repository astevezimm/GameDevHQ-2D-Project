using UnityEngine;

public class ShieldBehaviour : PowerUpBehaviour
{
    private PlayerDamage _playerDamage;
    
    protected override void Activate(Collider2D player)
    {
        _playerDamage = player.GetComponent<PlayerDamage>();
        _playerDamage.ActivateShield();
    }

    protected override void Deactivate() => _playerDamage.DeactivateShield();
}