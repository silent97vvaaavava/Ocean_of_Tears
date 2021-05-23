using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnemyFight : MonoBehaviour
{
    public EnemyType enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            HeroData._instantion.pause = false;
            WindowFight._instantion.enemyShip.enemy = enemy;
            WindowFight._instantion.windowFight.SetActive(true);
            FightEnemyShip._instantion.GetTypeEnemy();
            FightHero._instantion.ChooseType();
        }
    }
}
