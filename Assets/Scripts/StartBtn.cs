using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class StartBtn : MonoBehaviour
{
    [SerializeField] Button start;

    void Start()
    {
        start.onClick.AddListener(() => SceneManager.LoadSceneAsync("Game"));
    }

    
}
