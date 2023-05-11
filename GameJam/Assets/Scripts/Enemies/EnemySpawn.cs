using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Priest;
    public GameObject Monk;
    public GameObject Angel;

    private int enemyTypesCount = 3;

    private float priestInterval = 2f;
    private float monkInterval = 2f;
    private float angelInrerval = 2f;
    
    [SerializeField] private int priestCount;
    [SerializeField] private int monkCount;
    [SerializeField] private int angleCount;

    public int totalEnemies;

    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform corner1;
    [SerializeField] private Transform corner2;



    // Start is called before the first frame update
    void Start()
    {
        int manualCount = GameObject.FindGameObjectsWithTag("Enemy").Length - enemyTypesCount;
        totalEnemies = priestCount + monkCount + angleCount + manualCount;

        minX = Mathf.Min(corner1.position.x, corner2.position.x);
        maxX = Mathf.Max(corner1.position.x, corner2.position.x);
        minY = Mathf.Min(corner1.position.y, corner2.position.y);
        maxY = Mathf.Max(corner1.position.y, corner2.position.y);


        if (priestCount > 0) StartCoroutine(spawnEnemy(priestInterval, Priest, 0, priestCount));
        if (monkCount > 0) StartCoroutine(spawnEnemy(monkInterval, Monk, 0, monkCount));
        if (angleCount > 0)  StartCoroutine(spawnEnemy(angelInrerval, Angel, 0, angleCount));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy, int numSpawned, int count)
    {
        Instantiate(enemy, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0), Quaternion.identity);
        ++numSpawned;
        yield return new WaitForSeconds(interval);
        if (numSpawned < count) StartCoroutine(spawnEnemy(interval, enemy, numSpawned, count));
    }
}