using UnityEngine;

/// <summary>
/// Скрипт хранящий действия маяка
/// </summary>
public class LighthouseTile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Выводить сообщение о сдачи рыбы или пополнении снастей
            ScoreCircle._instantion.GetNewDay();

        }
    }
}