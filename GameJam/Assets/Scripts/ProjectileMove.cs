using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float randomness = 0.2f;

    void Start()
    {
        float interval = Random.Range(-randomness, randomness);

        rb = GetComponent<Rigidbody2D>();
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );
        rb.velocity = direction.normalized * moveSpeed;
        Vector2 kolmice = new Vector2(-direction.y, direction.x).normalized * interval;
        rb.velocity += kolmice;
    }

    // Update is called once per frame
    void Update()
    {
        int deathZone = 10;
        if (transform.position.x < -deathZone || transform.position.x > deathZone 
            || transform.position.y < -deathZone || transform.position.y > deathZone)
        {
            Destroy(gameObject);
        }
    }
}
