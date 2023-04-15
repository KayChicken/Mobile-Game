using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public bool gameIsPaused = false;
    public GameObject pauseUI;
    public static int currectLevel = 1;
   


    


    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0.0f;
    }


    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = !gameIsPaused;
    }


    public void PauseButton()
    {
        gameIsPaused = !gameIsPaused;

        if (gameIsPaused)
        {
            Pause();
        }

        else
        {
            Resume();
        }
    }


    public void ExitToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
