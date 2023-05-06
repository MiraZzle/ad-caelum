using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMove : MonoBehaviour
{
    private GameObject player;
    public AIPath aipath;
    private float radius = 8f;
    public bool canMove = true;

    private Vector2 direction;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        aipath.canMove = false;

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
        var positionEnemy = transform.position;

        float distance = Vector2.Distance(positionEnemy, positionPlayer);
        //Debug.Log($"dist = {distance.ToString()}");

        if (distance < radius)
        {
            Debug.Log($"dist = {distance.ToString()}");

            aipath.canMove = true;
        }
        

    }

}