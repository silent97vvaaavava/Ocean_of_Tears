using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllFish : MonoBehaviour
{
    public static AllFish _instantion;

    [SerializeField] EnemyType boss;
    [SerializeField] FightEnemyShip enemyShip;
    [SerializeField] Image image;

    int fish;
    int targetFish = 750;

    private void Awake()
    {
        _instantion = this;
    }


    public void GetFish(int getFish)
    {
        fish += getFish;

        image.fillAmount = (float)fish / (float)targetFish;

        if(fish >= targetFish)
        {
            enemyShip.enemy = boss;
        }
        
    }

}
