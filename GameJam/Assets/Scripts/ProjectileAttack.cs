using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    public int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyLife>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
