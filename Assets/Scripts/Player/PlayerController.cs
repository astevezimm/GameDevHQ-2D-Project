using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    private static PlayerInput _playerInput;
    
    private void Awake()
    {
        _playerInput = FindObjectOfType<PlayerInput>();
        GameManager.OnPlayerDeath += () => gameObject.SetActive(false);
    }

    public static Vector2 Movement => _playerInput.actions["Movement"].ReadValue<Vector2>();
    
    public static event Action OnFire;

    public void Fire(InputAction.CallbackContext context) => PerformAction(context, OnFire);
    
    private void PerformAction(InputAction.CallbackContext context, Action action)
    {
        if (context.performed)
            action?.Invoke();
    }
}
