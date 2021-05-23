using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMermaid : Tile
{
    public int addDamage = 5;
    public int decSpeed = 1;
    public float chancePirates = 0.2f;

    public override void GetCharacteristics()
    {
        HeroData._instantion.speed -= decSpeed;
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
