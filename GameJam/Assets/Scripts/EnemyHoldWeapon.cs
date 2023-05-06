using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHoldWeapon : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float posY = enemy.transform.position.y - 0.3f;
        float posX = enemy.transform.position.x;

        if (player.transform.position.x < enemy.transform.position.x)
        {
            transform.position = new Vector2(posX - 0.3f, posY);
        }
        else
        {
            transform.position = new Vector2(posX + 0.3f, posY);
        }
    }
}
