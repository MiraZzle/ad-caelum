using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float randomness = 0.2f;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        float interval = Random.Range(-randomness, randomness);

        rb = GetComponent<Rigidbody2D>();
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
            mousePosition.x - player.transform.position.x,
            mousePosition.y - player.transform.position.y
        );
        rb.velocity = direction.normalized * moveSpeed;
        Vector2 kolmice = new Vector2(-direction.y, direction.x).normalized * interval;
        rb.velocity += kolmice;
    }
}
