using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCharacteristics : MonoBehaviour
{
    [SerializeField] Text description;

    private void Start()
    {
        Show();
    }

    public void Show()
    {
        description.text = $"Жизни - {HeroData._instantion.health} \n" +
            $"Количество снастей - {HeroData._instantion.tackle} \n" +
            $"Урон - {HeroData._instantion.minDamage} - {HeroData._instantion.maxDamage} \n" +
            $"Скорость - {HeroData._instantion.speed} \n";
    }
}
