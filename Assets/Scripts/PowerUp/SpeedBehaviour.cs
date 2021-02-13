using UnityEngine;

public class SpeedBehaviour : PowerUpBehaviour
{
    private PlayerMovement _playerMovement;
    
    protected override void Activate(Collider2D player)
    {
        _playerMovement = player.GetComponent<PlayerMovement>();
        _playerMovement.ActivateSpeed();
    }

    protected override void Deactivate() => _playerMovement.DeactivateSpeed();
}