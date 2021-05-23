using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class GeneratedTrajectory : MonoBehaviour
{
    [SerializeField] Tilemap mapTrajectory;

    [SerializeField] TileBase tileTemp;

    public GameObject spawn;

    public Transform[] randomPointsPrefab;

    List<Vector3Int> pointForTrajectory = new List<Vector3Int>(); 
    Transform[] points;

    List<Vector3> worldPosCell = new List<Vector3>();
    public List<Vector3> WorldPosCell { get => worldPosCell; set => worldPosCell = value; } 

    private void Awake()
    {
        System.Random random = new System.Random();

        points = GetRandomPrefabs(random);

        for (int i = 0; i < points.Length; i++)
        {
            pointForTrajectory.Add(mapTrajectory.WorldToCell(points[i].position));
        }

        GetPointForDrawLine();

        
    }


    Transform[] GetRandomPrefabs(System.Random random)
    {
        int item = random.Next(randomPointsPrefab.Length - 1);

        randomPointsPrefab[item].GetComponent<RandomPoints>().GetPoints();
        return randomPointsPrefab[item].GetComponent<RandomPoints>().GetPoints();
    }

    void SetTile()
    {
        foreach (var item in pointForTrajectory)
        {
            mapTrajectory.SetTile(item, tileTemp);
        }
    }


    void GetPointForDrawLine()
    {
        // преобразуем центры клеток в мировые координаты
        foreach (var item in pointForTrajectory)
        {
            worldPosCell.Add(mapTrajectory.GetCellCenterWorld(item));
        }

    }

  

}
