/*using System.Collections;
using System.Collections.Generic;*/
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float movingSpeed = 10f;
    private Rigidbody2D rb;

    private float minMovingSpeed = 0.1f;
    private bool isRunning = false;

    private void Awake()
    {
         // Инициализация синглтона
        Instance = this;

        // Инициализация компонента Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
         // Обработка движения игрока
        HandleMovement();
    }

    private void HandleMovement()
    {
        // Получение вектора движения от ввода
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        // Нормализация вектора движения
        inputVector = inputVector.normalized;
         // Перемещение игрока
        rb.MovePosition(rb.position + inputVector * movingSpeed * Time.fixedDeltaTime);

        // Проверка, бежит ли игрок
        if (Math.Abs(inputVector.x) > minMovingSpeed || Math.Abs(inputVector.y) > minMovingSpeed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
     // Получение состояния "бег" игрока
    public bool IsRunning()
    {
        return isRunning;
    }

     // Получение экранных координат игрока
    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
}