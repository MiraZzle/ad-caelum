using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    int enemiesInLevel;
    public int killedEnemies;
    public bool levelWon = false;

    void Start()
    {
        GameObject spawner = GameObject.FindGameObjectWithTag("Spawner");
        enemiesInLevel = spawner.GetComponent<EnemySpawn>().totalEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        if (killedEnemies == enemiesInLevel)
        {
            levelWon = true;
        }
    }
}
