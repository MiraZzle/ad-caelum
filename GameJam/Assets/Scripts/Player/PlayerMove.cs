using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private PlayerLife playerLifeManager;

    private Animator anim;
    public ParticleSystem player_trail;

    public static float moveSpeed = 5f;


    void Start() {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerLifeManager = GetComponent<PlayerLife>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerLifeManager.isAlive)
        {
            float dirX = Input.GetAxisRaw("Horizontal");
            float dirY = Input.GetAxisRaw("Vertical");
            Vector2 velocity = new Vector2(dirX, dirY);
            velocity = velocity.normalized * moveSpeed;
            rb.velocity = velocity;
            AnimationUpdate(dirX, dirY);
            flipTowardMouse();
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void AnimationUpdate(float dirX, float dirY) {
        if (dirX == 0f && dirY == 0f) {
            anim.SetBool("running", false);
        } else {
            playParticle();
            anim.SetBool("running", true);
        }
    }

    void flipTowardMouse() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (mousePosition.x < transform.position.x) {
            sprite.flipX = true;
        }
        else {
            sprite.flipX = false;
        }
    }

    private void playParticle() {
        player_trail.Play();
    }
}
