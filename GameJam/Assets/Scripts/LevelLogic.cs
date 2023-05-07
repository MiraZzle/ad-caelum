using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLogic : MonoBehaviour
{
    public int killedEnemies;
    public bool levelWon = false;
    [SerializeField] private EnemySpawn spawnScript;

    void Update()
    {
        if (killedEnemies == spawnScript.totalEnemies)
        {
            levelWon = true;
        }

        if (levelWon && SceneManager.GetActiveScene().name == "Boss")
        {
            SceneManager.LoadScene("EndScreenWinning");
        }
    }
}
