using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    public List<GameObject> levels;
    public static int countLevels;

    
 
    void Start()
    {
        countLevels = levels.Count;
        SetLevels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetLevels()
    {
        for (int i = 0; i < GameManager.currectLevel; i++)
        {
            levels[i].SetActive(true);
        }
    }


    public void ChooseLevel_1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void ChooseLevel_2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void ChooseLevel_3()
    {
        SceneManager.LoadScene("Level_3");
    }








}
