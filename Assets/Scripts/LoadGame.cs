using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex == 1 && Input.GetKeyDown(KeyCode.R) ||
            SceneManager.GetActiveScene().buildIndex == 2 && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(0); // Game Scene
        }
    }
}
