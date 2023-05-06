using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject Priest;
    [SerializeField]
    private GameObject Monk;
    [SerializeField]
    private GameObject Angel;

    private float priestInterval = 3f;
    private float monkInterval = 4f;
    private float angelInrerval = 5f;

    [SerializeField] private int priestCount = 3;
    [SerializeField] private int monkCount = 3;
    [SerializeField] private int angleCount = 3;
    public int totalEnemies;

    [SerializeField] private float minX = 1;
    [SerializeField] private float maxX = 1;
    [SerializeField] private float minY = 3;
    [SerializeField] private float maxY = 3;


    // Start is called before the first frame update
    void Start()
    {
        totalEnemies = priestCount + monkCount + angleCount;

        if (priestCount > 0) StartCoroutine(spawnEnemy(priestInterval, Priest, 0, priestCount));
        if (monkCount > 0) StartCoroutine(spawnEnemy(monkInterval, Monk, 0, monkCount));
        if (angleCount > 0)  StartCoroutine(spawnEnemy(angelInrerval, Angel, 0, angleCount));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy, int numSpawned, int count)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0), Quaternion.identity);
        if (numSpawned + 1 < count) StartCoroutine(spawnEnemy(interval, enemy, numSpawned + 1, count));
    }
}