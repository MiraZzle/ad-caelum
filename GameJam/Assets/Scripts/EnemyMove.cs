using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMove : MonoBehaviour
{
    private GameObject player;
    public AIPath aipath;
    public float radius = 3.0f;
    public bool canMove = true;

    private Vector2 direction;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        Velocity();
    }

    private void Velocity()
    {
        var positionPlayer = player.transform.position;
        var positionEnemy = aipath.position;

        float distance = Vector2.Distance(positionEnemy, positionPlayer);
        if (distance < radius)
        {
            //transform.stop();
            canMove = true;
            aipath.canMove = canMove;
            Debug.Log("Oh no");
        }

    }

}