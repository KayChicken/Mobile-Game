using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Spawn Config" , menuName = "Spawn")]
public class SpawnerConfig : ScriptableObject
{
    public int wave;
    public int enemyCount;
    public float timePerSpawn;
    public List<GameObject> enemies;

}
