using UnityEngine;

public class PlayerDamageFX : MonoBehaviour
{
    private GameObject _rightDamage, _leftDamage;

    private void Awake()
    {
        _rightDamage = transform.GetChild(0).gameObject;
        _leftDamage = transform.GetChild(1).gameObject;
        PlayerDamage.OnLivesChanged += HandleLivesChanged;
    }

    private void HandleLivesChanged(int lives)
    {
        switch (lives)
        {
            case 3:
                _rightDamage.SetActive(false);
                _leftDamage.SetActive(false);
                break;
            case 2:
                _rightDamage.SetActive(true);
                _leftDamage.SetActive(false);
                break;
            case 1:
                _rightDamage.SetActive(true);
                _leftDamage.SetActive(true);
                break;
            default:
                if (lives > 3)
                {
                    _rightDamage.SetActive(false);
                    _leftDamage.SetActive(false);
                }
                break;
        }
    }
}
