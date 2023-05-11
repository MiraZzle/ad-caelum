using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = PlayerMove.moveSpeed;
    [SerializeField] PlayerAttack attack;
    GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!attack.stabbing)
        {
            transform.position = player.transform.position;
            faceMouse();
        }
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
