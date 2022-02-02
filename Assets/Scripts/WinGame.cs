using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    Grid dotGrid;

    private void Start()
    {
        dotGrid = GameObject.FindObjectOfType<Grid>();
    }

    private void Update()
    {
        if (dotGrid.dotCount == 0)
        {
            SceneManager.LoadSceneAsync(1); // Win Scene
        }
    }
}
