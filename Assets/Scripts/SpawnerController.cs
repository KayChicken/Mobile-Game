using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class SpawnerController : MonoBehaviour
{
    public List<SpawnerConfig> spawnerConfigs;
    public List<Transform> spawnPoints;
    public bool isAllDeath = false;
    public bool isSpawned = false;
    public int currentWave = 0;
    public int enemiesCount = 0;
    public TextMeshProUGUI waveText;
    public WinScript winScript;
    public bool stopCheck = false;
    
    void Start()
    {
        TextAnimation();
    }

    
    void Update()
    {
        if (isSpawned != true && enemiesCount < spawnerConfigs[currentWave].enemyCount)
        {
            SpawnEnemies(currentWave);
            
        }
        


        else if (enemiesCount == spawnerConfigs[currentWave].enemyCount)
        {
            if (!stopCheck)
            {
                CheckDeath();
            }
            
        }






    }
    


    public void SpawnEnemies(int currentWave)
    {
        int randomEnemy = Random.Range(0, spawnerConfigs[currentWave].enemies.Count);
        int randomPoint = Random.Range(0, spawnPoints.Count);
        Instantiate(spawnerConfigs[currentWave].enemies[randomEnemy], spawnPoints[randomPoint]);
        isSpawned = true;
        enemiesCount++;
        StartCoroutine(WaitPerSpawn(spawnerConfigs[currentWave].timePerSpawn));
    }



    IEnumerator WaitPerSpawn(float time)
    {
        yield return new WaitForSeconds(time);
        isSpawned = false;
    }



    void TextAnimation()
    {
        waveText.text = $"Wave : {currentWave + 1}";
        waveText.DOFade(1, 2).SetLoops(2, LoopType.Yoyo).Play();
    }



    public void CheckDeath()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (enemies.Length == 0 || enemies == null)
        {
            isAllDeath = true;

            if (currentWave + 1 < spawnerConfigs.Count)
            {
                currentWave++;
                TextAnimation();
                isSpawned = false;
                isAllDeath = false;
                enemiesCount = 0;
            }

            else
            {
                stopCheck = true;
                winScript.ShowWin();


            }
        }
    }



   


   



    


    
    
}

