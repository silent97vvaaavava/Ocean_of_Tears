using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCircle : MonoBehaviour, IObserver
{
    public static ScoreCircle _instantion;

    [SerializeField] Image imageDay;
    [SerializeField] GeneratedTrajectory trajectory;
    [SerializeField] Text numberCircle;

    float allLength;
    int number = 0;

    private void Awake()
    {
        _instantion = this;
    }

    private void Start()
    {
        numberCircle.text = number.ToString();
        GetLengthRoad();
        //Debug.Log(allLength);
    }


    void GetLengthRoad()
    {
        var points = trajectory.WorldPosCell;
        for (int i = 0; i < points.Count; i++)
        {
            if (i == points.Count - 1)
            {
                allLength += Vector3.Distance(points[i], points[0]);
            }
            else
                allLength += Vector3.Distance(points[i], points[i + 1]);
        }
    }

    public void StateUpdate(ISubject subject)
    {
        ShowProgress((subject as MovmentHero).CurrentLength);
    }


    void ShowProgress(float currentLength)
    {
        var delta = currentLength / allLength;
        imageDay.fillAmount = delta;
    }

    public void GetNewDay()
    {
        if (number > 1 && !WindowFight._instantion.windowNotify.activeSelf)
        {
            WindowFight._instantion.windowNotify.SetActive(true);
            RandomStatePirates._instantion.GeneratedPirates();
        }
        number += 1;
        numberCircle.text = (number-1).ToString();

    }
}
