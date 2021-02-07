using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int lives = 3;
    
    public void TakeDamage()
    {
        lives--;
        // check for death
    }
}
