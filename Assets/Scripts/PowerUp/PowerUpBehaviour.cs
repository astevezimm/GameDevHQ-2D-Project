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