/*using System.Collections;
using System.Collections.Generic;*/
// PlayerVisual.cs
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private const string IS_RUNNING = "IsRunning";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Устанавливаем состояние анимации "бег" в зависимости от переменной isRunning в Player
        animator.SetBool(IS_RUNNING, Player.Instance.IsRunning());

        // Проверяем положение мыши относительно игрока и отражаем спрайт горизонтально
        AdjustPlayerFacingDirection();
    }

    private void AdjustPlayerFacingDirection()
    {
        // Получаем текущие координаты мыши
        Vector3 mousePos = GameInput.Instance.GetMousePosition();
        // Получаем текущие экранные координаты игрока
        Vector3 playerPosition = Player.Instance.GetPlayerScreenPosition();

         // Отражаем спрайт горизонтально в зависимости от положения мыши
        if (mousePos.x < playerPosition.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
