/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
         // Инициализация синглтона
        Instance = this;
        
        // Инициализация объекта для управления вводом
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

     // Получение вектора движения от ввода игрока
    public Vector2 GetMovementVector()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

    // Получение текущей позиции мыши
    public Vector3 GetMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        return mousePos;
    }
}