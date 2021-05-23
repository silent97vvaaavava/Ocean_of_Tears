using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowFight : MonoBehaviour
{
    public static WindowFight _instantion;
    public GameObject windowFight;
    public FightEnemyShip enemyShip;

    public GameObject windowNotify;

    private void Awake()
    {
        _instantion = this;
    }
}
