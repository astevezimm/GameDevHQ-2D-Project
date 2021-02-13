using System.Collections;
using UnityEngine;

public abstract class PowerUpBehaviour
{
    private WaitUntil _waitUntil;

    private float _coolDownTime;
    
    public void Activate(Collider2D player, float coolDown)
    {
        _waitUntil ??= new WaitUntil(Interval);
        _coolDownTime = Time.time + coolDown;
        player.GetComponent<Input>().StartCoroutine(CoolDown(player));
    }

    protected abstract void Activate(Collider2D player);
    protected abstract void Deactivate();

    private IEnumerator CoolDown(Collider2D player)
    {
        Activate(player);
        yield return _waitUntil;
        Deactivate();
    }

    private bool Interval() => Time.time >= _coolDownTime;
}

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