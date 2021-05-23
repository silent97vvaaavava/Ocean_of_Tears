using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCliff : Tile
{
    public int addSpeed = 2;
    public int addDamage = 1;
    public float chancePirates = 0.1f;


    public override void GetCharacteristics() 
    {
        HeroData._instantion.speed += addSpeed;
        HeroData._instantion.minDamage += addDamage;
        HeroData._instantion.maxDamage += addDamage;
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
