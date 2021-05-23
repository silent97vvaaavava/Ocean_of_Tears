using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;


public class DrawLine : MonoBehaviour
{
    [Header("Установка маяка")]
    [SerializeField] GameObject lighthousePref;

    [Header("Карты")]
    [SerializeField] Tilemap mapSea;
    [SerializeField] Tilemap mapPreroad;
   [Header("Вспомогательные вещи")]
    public Tilemap mapTrajectory;
    public TileBase newTile;
    [Range(1, 10)] public float speed;
    

    [Header("Префаб игрока")]
    [SerializeField] GameObject heroPref;
    [SerializeField] Button button;
    public GeneratedTrajectory pointsList;

    List<Vector3> points = new List<Vector3>();
    int next = 0;

    private void Awake()
    {
    }

    private void Start()
    {
        points = pointsList.WorldPosCell;

        transform.position = points[0];
        Instantiate(lighthousePref, points[0], Quaternion.identity);

    }

    private void Update()
    {
        Movment();
    }


    void Movment()
    {
        

        if (next > points.Count)
        {
            Instantiate(heroPref, points[0], Quaternion.identity).GetComponent<MovmentHero>().SetPoints(points, button);
            //Instantiate(lighthousePref, points[0], Quaternion.identity);

            Destroy(this.gameObject);
        }
        transform.position = Vector3.MoveTowards(transform.position, points[next % points.Count], speed * Time.deltaTime);

        SetTile();
        if (Vector3.Distance(transform.position, points[next % points.Count]) < 0.2f) next++;
    }

    // проверить есть ли снизу тайл
    // если нет, то поставить
    void SetTile()
    {
        var tilePos = mapTrajectory.WorldToCell(transform.position);
        if (!mapTrajectory.HasTile(tilePos))
        {
            mapTrajectory.SetTile(tilePos, newTile);
        }
        if (mapPreroad.HasTile(tilePos))
        {
            mapPreroad.SetTile(tilePos, null);
        }
        if(mapSea.HasTile(tilePos))
        mapSea.SetTile(tilePos, null);
    }

    
}

