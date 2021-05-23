using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStatePirates : MonoBehaviour
{

    // получить позиции 
    // выбрать случайную 
    //проверить нет ли точки в массиве
    //записать ее в массив 
    // поставить в эту точку пирата 

    public static RandomStatePirates _instantion;

    [SerializeField] GameObject piratesPref;

    [SerializeField] GeneratedTrajectory trajectory;
    List<Vector3> points = new List<Vector3>();
    List<Vector3> tempPoints = new List<Vector3>();



    private void Awake()
    {
        _instantion = this;
    }

    private void Start()
    {
        points = trajectory.WorldPosCell;
        //Debug.Log(points.Count);
        GeneratedPirates();

    }

    public void GeneratedPirates()
    {
        System.Random random = new System.Random();
        int number = random.Next(points.Count - 1);
        var temp = Instantiate(piratesPref, points[number], Quaternion.identity);

    }
}
