using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour {
    [SerializeField] private AudioSource FireBallSoundEffect;

    public int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision) {
        FireBallSoundEffect.Play();
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<EnemyLife>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "wall") {
            Destroy(gameObject);
        }
    }
}
