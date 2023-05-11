using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class KrucufixAttack : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject enemy;
    float moveSpeed = 5f;
    private Rigidbody2D rb;
    bool throwing = false;
    [SerializeField] private float attackRadius = 4f;
    [SerializeField] private float randomness = 0.2f;
    int damage = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var positionPlayer = player.transform.position;
        var positionEnemy = enemy.transform.position;
        float distance = Vector2.Distance(positionEnemy, positionPlayer);

        if (!throwing)
        {
            if (distance < attackRadius)
            {
                ThrowKrucufix();
            }
            else
            {
                HoldWeapon();
            }
        }
    }

    private void HoldWeapon()
    {
        float posY = enemy.transform.position.y - 0.1f;
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

    private void ThrowKrucufix()
    {
        var positionPlayer = player.transform.position;
        var positionEnemy = enemy.transform.position;
        throwing = true;
        Vector2 direction = new Vector2(
            positionPlayer.x - positionEnemy.x,
            positionPlayer.y - positionEnemy.y
        );

        float interval = Random.Range(-randomness, randomness);


        rb.velocity = direction.normalized * moveSpeed;
        Vector2 kolmice = new Vector2(-direction.y, direction.x).normalized * interval;
        rb.velocity += kolmice;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLife>().TakeDamage(damage);
            throwing = false;

            HoldWeapon();


        }
        if (collision.gameObject.tag == "wall")
        {
            throwing = false;


            HoldWeapon();
        }
    }
}
