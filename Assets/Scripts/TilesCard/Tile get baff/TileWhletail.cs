using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileWhletail : Tile
{
    public int addSpeed = 4;
    public int decTackle = 1;
    public int addDamage = 1;

    public override void GetCharacteristics()
    {
        HeroData._instantion.speed -= addSpeed;
        HeroData._instantion.minDamage += addDamage;
        HeroData._instantion.maxDamage += addDamage;
        HeroData._instantion.tackle -= decTackle;
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
