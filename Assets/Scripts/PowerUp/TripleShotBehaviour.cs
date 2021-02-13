using UnityEngine;

public class TripleShotBehaviour : PowerUpBehaviour
{
    private PlayerFire _playerFire;
    
    protected override void Activate(Collider2D player)
    {
        _playerFire = player.GetComponent<PlayerFire>();
        _playerFire.ActivateTripleShot();
    }

    protected override void Deactivate() => _playerFire.DeactivateTripleShot();
}