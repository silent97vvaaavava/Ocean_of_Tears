using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowCountFish : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] GameObject text;

    private void Awake()
    {
        button.onClick.AddListener(() => ViewFish());
    }

    void ViewFish()
    {
        if(!text.activeSelf)
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
        text.GetComponent<Text>().text = $"Всего рыбы: {HeroData._instantion.countFish.ToString()}";
    }
}
