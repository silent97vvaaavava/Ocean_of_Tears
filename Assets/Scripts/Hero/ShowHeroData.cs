using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// отображаем текущее значение жизней и снастей
public class ShowHeroData : MonoBehaviour, IObserver
{
    [Header("Отображение количества жизней")]
    [SerializeField] Image healthImage;
    [SerializeField] Text healthText;
    [SerializeField] Text healthAllText;


    [Header("Отображение количество снастей")]
    [SerializeField] Image tackleImage;
    [SerializeField] Text tackleText;
    [SerializeField] Text tackleAllText;

    [Header("Отобржение текущих характеристик")]
    [SerializeField] Text descrText;


    private void Start()
    {
        HeroData._instantion.Atach(this);
        SetTextData(HeroData._instantion);
    }

    public void StateUpdate(ISubject subject)
    {
        SetTextData(subject as HeroData);
    }

    void SetTextData(HeroData data)
    {
        healthAllText.text = data.health.ToString();
        healthText.text = data.currentHealth.ToString();

        healthImage.fillAmount = (float)data.currentHealth / (float)data.health;

        tackleAllText.text = data.tackle.ToString();
        tackleText.text = data.currentTackle.ToString();

        tackleImage.fillAmount = (float)data.currentTackle / (float)data.tackle;

    }


}
