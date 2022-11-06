using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject gameOver;
    public GameObject UI;
    public GameObject instructionPanel;


    void Awake() 
    {
        startScreen.SetActive(true);
        gameOver.SetActive(false);
        UI.SetActive(false);
        instructionPanel.SetActive(false);
        Time.timeScale = 0;
    }

    public void OnStartButton()
    {
        startScreen.SetActive(false);
        UI.SetActive(true);
        instructionPanel.SetActive(true);
    }

    public void OnStart()
    {
        Time.timeScale = 1;
        instructionPanel.SetActive(false);
    } 

    public void OnGameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    public void OnReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
