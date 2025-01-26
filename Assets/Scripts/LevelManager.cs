using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public PlayerScore playerScore;
    public PlayerHealth playerHealth;
    private bool isPaused = false;
    private bool isWin = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        if(playerScore.getCurrentScore() >= 40)
        {
            playerWin();
        }
        if(playerHealth.getCurrentHealth() <= 0)
        {
            GameOver();
        }
        
    }

    public void playerWin()
    {
        isWin = true;
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

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu"); 
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void GameOver()
    {
        

    }
}
