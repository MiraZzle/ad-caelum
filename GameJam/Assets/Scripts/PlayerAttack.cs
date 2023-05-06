using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform firePosition;
    [SerializeField] GameObject projectile;
    GameObject player;
    private static float stabDuration = 0.2f;
    private static float stabRange = 3;
    private float stabVelocity = stabRange / stabDuration;
    private Vector3 stabDir;
    private float timer = 0f;
    public int stabDamage = 2;

    public bool stabbing = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !stabbing)
        {
            Instantiate(projectile, firePosition.position, firePosition.rotation); 
        }
        if (Input.GetKeyDown(KeyCode.Space) && !stabbing) 
        {
            stabbing = true;
            stabDir = getStabDir();
        }

        if (stabbing) Stab(stabDir);
    }

    private Vector3 getStabDir()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 direction = new Vector3(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y,
            0
        ).normalized;

        return direction;
    }

    private void Stab(Vector3 dir)
    {
        timer += Time.deltaTime;

        if (timer < stabDuration / 2)
        {
            transform.position += dir * Time.deltaTime * stabVelocity;
        }
        else
        {
            transform.position -= dir * Time.deltaTime * stabVelocity;
        }

        if (timer >= stabDuration)
        {
            stabbing = false;
            timer = 0f;
            transform.position = player.transform.position;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyLife>().TakeDamage(stabDamage);
        }
    }
}
