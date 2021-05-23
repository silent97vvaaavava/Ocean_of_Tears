using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileIsland : Tile
{
    public int addTackle = 3;
    public int addHealth = 5;
    public int decDamage = 1;

    public override void GetCharacteristics()
    {
        HeroData._instantion.tackle += addTackle;
        HeroData._instantion.health += addHealth;
        HeroData._instantion.minDamage -= decDamage;
        HeroData._instantion.maxDamage -= decDamage;

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
