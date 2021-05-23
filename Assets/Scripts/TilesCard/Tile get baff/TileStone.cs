using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStone : Tile
{
    public int damage = 1;

    public override void GetCharacteristics()
    {
        HeroData._instantion.maxDamage += damage;
        HeroData._instantion.minDamage += damage;
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
