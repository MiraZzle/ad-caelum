using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelProjectileMove : MonoBehaviour
{
    private Rigidbody2D rb;
    int damage = 2;

    float moveSpeed = 7f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        var v = transform.localRotation * new Vector3(0, 1, 1);
        rb.velocity = v * moveSpeed;

    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLife>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
