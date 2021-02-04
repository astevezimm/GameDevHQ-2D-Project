using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Projectile laserPrefab;

    private void Awake() => Input.OnFire += HandleFire;

    private void HandleFire()
    {
        //todo: cool down
        laserPrefab.Get(); //todo: tranform
    }
}
