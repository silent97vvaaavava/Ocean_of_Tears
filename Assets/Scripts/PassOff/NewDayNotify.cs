using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewDayNotify : MonoBehaviour
{
    [SerializeField] Button passOff;
    [SerializeField] Button getTackle;

    private void Awake()
    {
        passOff.onClick.AddListener(() => PassOffFish());
        getTackle.onClick.AddListener(() => GetTackle());
    }

    void GetTackle()
    {
        HeroData._instantion.currentTackle = HeroData._instantion.tackle;
        HeroData._instantion.Notify();
        gameObject.SetActive(false);
    }

    void PassOffFish()
    {
        AllFish._instantion.GetFish(HeroData._instantion.countFish);

        HeroData._instantion.countFish = 0;
        gameObject.SetActive(false);
    }
}
