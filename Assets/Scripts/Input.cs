using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    private static PlayerInput _playerInput;
    
    private void Awake() => _playerInput = GetComponent<PlayerInput>();
    
    public static Vector2 Movement => _playerInput.actions["Movement"].ReadValue<Vector2>();
}
