using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {
    public int hp = 20;
    public bool isALive = true;
    private SimpleFlash simpleFlash;
    private Animator anim;

    void Start() {
        simpleFlash = gameObject.GetComponent<SimpleFlash>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage) {
        hp -= damage;
        if (hp <= 0) {
            isALive = false;
            anim.SetBool("isDead", true);
            Invoke("Death", 1f);
        } else {
            simpleFlash.Flash();
        }
    }

    void Death() {
        SceneManager.LoadScene("EndScreenLosing");
    }
}
