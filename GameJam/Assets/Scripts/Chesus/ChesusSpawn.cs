using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChesusSpawn : MonoBehaviour
{
    EnemySpawn enemySpawner;
    [SerializeField] GameObject chesus;
    float spawnRadius = 2f;
    float spawnCooldown = 5f;
    float timer = 0;

    void Start()
    {
        enemySpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawn>();   
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnCooldown )
        {
            timer -= spawnCooldown;
            spawnAngel();
        }
    }

    public List<GameObject> spawnedAngels = new List<GameObject>();
    void spawnAngel()
    {
        float randomAngle = Random.Range(0, 2*Mathf.PI);
        Vector3 chesusPos = chesus.transform.position;
        Vector3 spawnPos = new Vector3(
            chesusPos.x + spawnRadius * Mathf.Cos(randomAngle),
            chesusPos.y + spawnRadius * Mathf.Sin(randomAngle)
            );
        GameObject angel = Instantiate(enemySpawner.Angel, spawnPos, Quaternion.identity);
        spawnedAngels.Add(angel);
        enemySpawner.totalEnemies++;
    }
}
