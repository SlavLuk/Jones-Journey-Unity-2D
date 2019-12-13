using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PauseMenu : MonoBehaviour
{
    
    
    public GameObject pauseMenuUI;
    private void Start()
    {
        
        Resume();

    }
  

    public void PauseBtn()
    {
        if (Time.timeScale == 1)
        {
            Pause();
           
        }
        else if (Time.timeScale == 0)
        {
            Resume();
           
        }

    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
      
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
      
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
       
        Application.Quit();
    }
}
