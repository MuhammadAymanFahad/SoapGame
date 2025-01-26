using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject pausePanel; 
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            TogglePause(); 
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused; 
        pausePanel.SetActive(isPaused);

  
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void ResumeGame()
    {
        isPaused = false; 
        pausePanel.SetActive(false); 
        Time.timeScale = 1f; 
    }
}

