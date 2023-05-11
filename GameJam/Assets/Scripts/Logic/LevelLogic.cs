using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLogic : MonoBehaviour
{
    public int killedEnemies;
    public bool levelWon = false;
    private EnemySpawn spawnScript;

    private void Start()
    {
        spawnScript = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawn>();
    }
    void Update()
    {
        if (killedEnemies >= spawnScript.totalEnemies)
        {
            levelWon = true;
        }

        if (levelWon && SceneManager.GetActiveScene().name == "Boss")
        {
            Invoke("BossDefeated", 2f);
        }
    }

    private void BossDefeated()
    {
        SceneManager.LoadScene("EndScreenWinning");
    }
}
