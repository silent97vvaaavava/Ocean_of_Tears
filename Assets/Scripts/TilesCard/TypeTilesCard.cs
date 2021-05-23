using UnityEngine;
using UnityEngine.Tilemaps;

public class TypeTilesCard : MonoBehaviour
{
    [Header("Пустой объект с данными")]
    public GameObject empty;

    public string targetTag;
    public SpriteRenderer sprite;

    [Header("Карта относительно которой ставим")]
    Tilemap current;

    [Header("Карта на которую ставим")]
    Tilemap targetMap;

    [Header("Тайл который поставим на карту")]
    [SerializeField] TileBase tileOnMap;

    [Header("Тайл который поставим на карту снизу")]
    [SerializeField] TileBase tileBack;

    [Header("Кнопка, которая вызвала тайл")]
    public GameObject buttonEvent;



    // позиция куда ставим тайл
    Vector3Int tempMapPosition;

    Camera mainCamera;

    bool check = false;

    private void Awake()
    {
        mainCamera = Camera.main;
    }


    private void Update()
    {
        if (!check)
        {
            SetPosition();
        }
        SetTileOnMap();

        DropTile();
    }

    void SetPosition()
    {
        Vector2 currentPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        this.gameObject.transform.position = currentPosition;

        // проверим тайл над которым находимся и пустой ли он
        tempMapPosition = current.WorldToCell(currentPosition);
        if (current.HasTile(tempMapPosition) && !targetMap.HasTile(tempMapPosition))
        {
            var positionWorld = current.GetCellCenterWorld(tempMapPosition);
            transform.position = positionWorld;
            sprite.color = Color.green;
        }
        else
        {
            sprite.color = Color.red;
        }

    }

    void SetTileOnMap()
    {
        if (sprite.color == Color.green && Input.GetMouseButtonDown(0))
        {
            check = true;

            targetMap.SetTile(tempMapPosition, tileOnMap);
            Destroy(this.gameObject, .3f);
            Destroy(buttonEvent);

            //gameObject.SetActive(false);
        }
    }

    void DropTile()
    {
        if (sprite.color == Color.red && Input.GetMouseButtonDown(1))
        {
            if (!buttonEvent.gameObject.activeSelf) buttonEvent.gameObject.SetActive(true);

            Destroy(this.gameObject, .3f);
        }
    }

    public void SetAllData(GameObject button, Tilemap current, Tilemap target)
    {
        this.current = current;
        targetMap = target;
        buttonEvent = button;
    }

    

}