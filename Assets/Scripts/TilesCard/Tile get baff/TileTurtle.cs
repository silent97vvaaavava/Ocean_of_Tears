using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTurtle : Tile
{
    public int decSpeed = 3;
    public int addTackle = 2;
    public int addDamage = 2; 

    public override void GetCharacteristics()
    {
        HeroData._instantion.speed -= decSpeed;
        HeroData._instantion.minDamage += addDamage;
        HeroData._instantion.maxDamage += addDamage;
        HeroData._instantion.tackle += addTackle;

    }

    private void OnDestroy()
    {
        if (!typeTile.buttonEvent)
        {
            GetCharacteristics();
            HeroData._instantion.Notify();

        }
    }
}
