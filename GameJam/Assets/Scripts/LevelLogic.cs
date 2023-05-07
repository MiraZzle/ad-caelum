using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    public int enemiesInLevel = -1;
    public int killedEnemies;
    public bool levelWon = false;
    [SerializeField] private EnemySpawn spawnScript;

    void Update()
    {
        if (killedEnemies == spawnScript.totalEnemies)
        {
            levelWon = true;
        }
    }
}
