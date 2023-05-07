using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChesusAttack : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float attackRadius = 10f;
    [SerializeField] GameObject projectile;
    GameObject player;
    float coolDown = 2f;
    float cdTimer = 0f;
    int angleArc = 20;
    bool animation = false;
    float animationTimer = 0f;
    float animationDurration = 0.3f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        cdTimer += Time.deltaTime;

        if (cdTimer > coolDown - animationDurration)
        {
            anim.SetBool("attack", true);
            animation = true;
        }

        if (animation) animationTimer += Time.deltaTime;
        if (animationTimer > animationDurration)
        {
            animation = false;
            anim.SetBool("attack", false);
            animationTimer = 0f;
        }

        if (cdTimer > coolDown)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < attackRadius)
            {
                cdTimer = 0f;
                FireProjectiles();
            }
        }
    }

    private void FireProjectiles()
    {
        Vector2 direction = new Vector2(
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y
        );


        for (int angleDiff = angleArc; angleDiff <= 360; angleDiff += angleArc)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleDiff;
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(projectile, transform.position, rotation);
        }
    }
}
