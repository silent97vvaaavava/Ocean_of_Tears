using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


/// <summary>
/// Рандомно выдавать карточку после боевки
/// </summary>
public class TileController : MonoBehaviour
{
    [Header("Сетки по которым ставить")]
    [SerializeField] Tilemap[] allMap;

    [Header("Сетка на которую ставятся все тайлы")]
    [SerializeField] Tilemap basicMap;

    [Header("Карточка")]
    [SerializeField] GameObject cardPref;

    [SerializeField] GameObject[] preroadObjets;
    [SerializeField] GameObject[] roadObjets;
    [SerializeField] GameObject[] seaObjets;

    [Header("Контейнер где лежат карты")]
    [SerializeField] RectTransform content;

    GameObject currentCard;

    public static TileController _instantion;

    private void Awake()
    {
        _instantion = this;
    }


    public void GetRandomCard()
    {
        System.Random random = new System.Random();

        // создать экземпляр
        currentCard = Instantiate(cardPref, content);
        
        // получить его скрипт
        var dataCard = currentCard.GetComponent<TilesDropAndDrag>();

        int currentNubmer = random.Next(allMap.Length);
        //GameObject[] currentObjets = null; // выбранный случайно массив тайлов
        switch (currentNubmer)
        {
            case 0:
                //currentObjets = preroadObjets;
                dataCard.SetDataForCard(allMap[currentNubmer], basicMap, preroadObjets);
                break;
            case 1:
                //currentObjets = roadObjets;
                dataCard.SetDataForCard(allMap[currentNubmer], basicMap, roadObjets);
                break;
            case 2:
                //currentObjets = seaObjets;
                dataCard.SetDataForCard(allMap[currentNubmer], basicMap, seaObjets);
                break;
        }
    }

    //сделать тест на получение карты

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetRandomCard();
        }
    }
}

