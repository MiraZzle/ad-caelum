using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BibleAttack : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    GameObject player;
    float attackRadius = 2f;
    int damage = 1;
    float animationDuration = 0.2f;
    float timer = 0f;
    float degreeStart = -100;
    float degreeDiff = 40;
    float coolDown = 0.7f;
    float cdTimer = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        var positionPlayer = player.transform.position;
        var positionEnemy = enemy.transform.position;
        float distance = Vector2.Distance(positionEnemy, positionPlayer);

        if (distance < attackRadius)
        {
            PrepareForBattle();
            SwingBook();
        }
        else
        {
            timer = 0f;
            HoldWeapon();
        }
    }
    private void HoldWeapon()
    {
        transform.rotation = Quaternion.identity;
        transform.position = new Vector2(
            enemy.transform.position.x,
            enemy.transform.position.y - 0.9f
            );
    }

    private void PrepareForBattle()
    {
        transform.position = new Vector2(
            enemy.transform.position.x,
            enemy.transform.position.y - 0.15f
            );
    }

    private void SwingBook()
    {
        timer += Time.deltaTime;
        float degrees = degreeStart + degreeDiff * timer / animationDuration;

        int sign = (player.transform.position.x < enemy.transform.position.x) ? -1 : +1;

        transform.eulerAngles = sign * Vector3.forward * degrees;

        if (timer > animationDuration)
        {
            timer = 0f;
            degreeStart += degreeDiff;
            degreeDiff *= -1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cdTimer += Time.deltaTime;
            if (cdTimer >= coolDown)
            {
                collision.gameObject.GetComponent<PlayerLife>().TakeDamage(damage);
                cdTimer -= coolDown;
            }
        }
    }
}
