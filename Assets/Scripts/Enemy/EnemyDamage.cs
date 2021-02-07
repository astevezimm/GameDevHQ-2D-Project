using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private const int PLAYER = 6;
    
    public void TakeDamage()
    {
        //todo Return();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerDamage>()?.TakeDamage();
        TakeDamage();
    }
}
