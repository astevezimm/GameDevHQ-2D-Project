using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    
    public void TakeDamage()
    {
        lives--;
        //todo check for death
    }
}
