using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(800, 600, false);
    }
    
    public void startButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main", UnityEngine.SceneManagement.LoadSceneMode.Single);
        GameManager.instance.player.Respawn();
        Debug.Log("Starting game!");
    }

    public void quitButton()
    {
        Application.Quit();
        Debug.Log("Quitting game!");
    }
}
