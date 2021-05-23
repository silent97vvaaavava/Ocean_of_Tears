using System.Collections.Generic;
using UnityEngine;

public class RandomPoints : MonoBehaviour
{
    [SerializeField] Transform[] points;

    public Transform[] GetPoints()
    {
        return points;
    }
}
