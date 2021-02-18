using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static PlayerInput _playerInput;
    
    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        GameManager.OnGameStart += () => gameObject.SetActive(true);
        GameManager.OnGameStop += () => gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public static Vector2 Movement => _playerInput.actions["Movement"].ReadValue<Vector2>();
    
    public static event Action OnFire;
    public static event Action OnSpeedBoostActivate;
    public static event Action OnSpeedBoostDeactivate;

    public void Fire(InputAction.CallbackContext context) => PerformAction(context, OnFire);

    public void SpeedBoost(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnSpeedBoostActivate?.Invoke();
        else if (context.canceled)
            OnSpeedBoostDeactivate?.Invoke();
    }
    
    private void PerformAction(InputAction.CallbackContext context, Action action)
    {
        if (context.performed)
            action?.Invoke();
    }
}
