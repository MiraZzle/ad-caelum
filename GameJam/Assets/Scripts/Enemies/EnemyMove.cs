using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMove : MonoBehaviour {
    public AIPath aipath;

    private float radius = 8f;
    private GameObject player;
    private Animator anim;
    private Vector2 direction;
    private SpriteRenderer sprite;
    private float lastStateX = 0f;
    private float lastStateY = 0f;

    private float idleCooldown = 0.15f;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start() {
        aipath.canMove = false;
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        float newX = transform.position.x;
        float newY = transform.position.y;

        if (player.transform.position.x < newX) {
            sprite.flipX = true;
        }
        else {
            sprite.flipX = false;
        }

        if (lastStateX == newX && lastStateY == newY)    //befX == lastStateX && lastStateY == befY
        {
            timer += Time.deltaTime;
            
        } else {
            timer = 0;
        }

        anim.SetBool("running", timer < idleCooldown);

        lastStateX = newX;
        lastStateY = newY;

        Velocity();
    }

    private void Velocity() {
        var positionPlayer = player.transform.position;
        var positionEnemy = transform.position;

        float distance = Vector2.Distance(positionEnemy, positionPlayer);

        if (distance < radius) {
            //Debug.Log($"dist = {distance.ToString()}");

            aipath.canMove = true;
        }
    }
}
