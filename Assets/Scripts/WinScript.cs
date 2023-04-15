using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public GameObject showMenu;
    public GameObject pauseButton;




    



    public void ShowWin()
    {
        if (GameManager.currectLevel < ChooseLevel.countLevels)
        {
            GameManager.currectLevel += 1;
        }
       

        pauseButton.SetActive(false);
        showMenu.SetActive(true);
       
        

    }


    public void Restart()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(4);
    }

    public void Menu()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(0);
    }



}
