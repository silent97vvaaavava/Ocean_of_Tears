using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEventX3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(HeroData._instantion.currentTackle == HeroData._instantion.tackle-1)
                HeroData._instantion.currentTackle += 1;
            else
            if (HeroData._instantion.currentTackle == HeroData._instantion.tackle - 2)
            {
                HeroData._instantion.currentTackle += 2;
            }
            if (HeroData._instantion.currentTackle < HeroData._instantion.tackle)
            {
                HeroData._instantion.currentTackle += 3;
            }
            HeroData._instantion.Notify();
            Debug.Log(gameObject.name);
        }
    }

   

    

}
