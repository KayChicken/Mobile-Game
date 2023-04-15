using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class DeathScript : MonoBehaviour
{
    
    public static CanvasGroup deathScene;
    public static GameObject pauseUI;


    private void Awake()
    {
        
        deathScene = GetComponent<CanvasGroup>();
        pauseUI = GameObject.Find("PauseButton");
    }

    public static void DeathMenu()
    {
       
        deathScene.DOFade(1, 2).Play();
        deathScene.interactable = true;
        deathScene.blocksRaycasts = true;
        pauseUI.SetActive(false);
    }


    public void Restart()
    {
        DOTween.KillAll();
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void Menu()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(0);
    }
}
