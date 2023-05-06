using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = PlayerMove.moveSpeed;
    [SerializeField] PlayerAttack attack;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
        Vector2 velocity = new Vector2(dirX, dirY);
        velocity = velocity.normalized * moveSpeed;
        rb.velocity = velocity;

        if (!attack.stabbing) faceMouse();

    }
    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;
    }
}
