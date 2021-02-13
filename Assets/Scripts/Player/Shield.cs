using UnityEngine;

public class Shield : MonoBehaviour
{
    private void Awake()
    {
        transform.parent.GetComponent<PlayerDamage>().OnShieldChanged += HandleShieldChanged;
        gameObject.SetActive(false);
    }

    private void HandleShieldChanged(bool active) => gameObject.SetActive(active);
}