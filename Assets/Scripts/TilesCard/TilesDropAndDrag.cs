using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class TilesDropAndDrag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // какой тайл будем ставить
    [Header("Тайл какой ставим")]
    [SerializeField] GameObject tilesGOPref; // для каждой кнопки свой префаб

    [Header("Сетка на какую смотрим, чтобы поставить тайл")]
    [SerializeField] Tilemap currentMap;     // каждая кнопка хранит свою сетку, сюда же помещаем и объекты которые расставили

    [Header("Сетка на которую ставим")]
    [SerializeField] Tilemap targetMap;

    [SerializeField] GameObject tileObject;  // объект который хранит параметры добавления для характеристик и т д

    Button currentBtnCard;

    [SerializeField] InfoCardTile InfoCard;

    private void Start()
    {

        GetComponent<Button>().onClick.AddListener(() => TapCardTile());        
    }

    void TapCardTile()
    {
        var nodeTile = Instantiate(tilesGOPref, transform.position, Quaternion.identity);
        var scriptTile = nodeTile.GetComponent<TypeTilesCard>();
        scriptTile.SetAllData(this.gameObject, currentMap, targetMap);
        if(gameObject.activeSelf)
        this.gameObject.SetActive(false);
    }
    
    public void SetDataForCard(Tilemap current, Tilemap target, GameObject[] tileObjects)
    {
        currentMap = current;
        targetMap = target;

        int count = tileObjects.Length;
        System.Random random = new System.Random();
        int numberTile = random.Next(count);
        tilesGOPref = tileObjects[numberTile];
        var dataTile = tilesGOPref.GetComponent<TileData>();
        InfoCard.SetInfo(dataTile.sprite, dataTile.name);
    }

    // опустить карточку
    public void OnPointerExit(PointerEventData eventData)
    {
        var tempPosition = transform.position;
        tempPosition.y = transform.position.y - .3f;
        transform.position = tempPosition;
    }

    //поднять карточку
    public void OnPointerEnter(PointerEventData eventData)
    {
        var tempPosition = transform.position;
        tempPosition.y = transform.position.y + .3f;
        transform.position = tempPosition;
    }
}
