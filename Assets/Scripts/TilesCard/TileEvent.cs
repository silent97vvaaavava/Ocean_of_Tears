using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEvent : MonoBehaviour
{
    [SerializeField] GameObject windowFight;
    [SerializeField] EnemyType type;

    int currHealth;

    private void Awake()
    {
        windowFight = WindowFight._instantion.windowFight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            type.currentHealth = type.health;
            if (!windowFight.activeSelf)
            {
                HeroData._instantion.pause = false;
                WindowFight._instantion.enemyShip.enemy = type;
                windowFight.SetActive(true);
                FightEnemyShip._instantion.GetTypeEnemy();
                FightHero._instantion.ChooseType();
            }
        }
    }

   
}
