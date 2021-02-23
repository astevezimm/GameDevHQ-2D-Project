using System.Collections;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private float blinkDuration = 2;
    
    private WaitForSeconds _waitForSeconds;
    
    private void Awake()
    {
        transform.parent.GetComponent<PlayerDamage>().OnShieldChanged += HandleShieldChanged;
        _waitForSeconds = new WaitForSeconds(ShieldBehaviour.CoolDown - blinkDuration);
        gameObject.SetActive(false);
    }

    private void HandleShieldChanged(bool active) => gameObject.SetActive(active);

    private void OnEnable() => StartCoroutine(Blink());

    private IEnumerator Blink()
    {
        yield return _waitForSeconds;
        //todo make shields blink before turning off
    }
}