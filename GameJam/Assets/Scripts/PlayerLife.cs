using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {
    public int hp = 20;
    public bool isALive = true;
    private SimpleFlash simpleFlash;
    private Animator anim;
    GameObject trident;

    void Start() {
        simpleFlash = gameObject.GetComponent<SimpleFlash>();
        trident = GameObject.FindGameObjectWithTag("trident");
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage) {
        hp -= damage;
        if (hp <= 0) {
            isALive = false;
            Destroy(trident);
            anim.SetBool("isDeat", true);
            Invoke("Death", 1f);
        } else {
            simpleFlash.Flash();
        }
    }

    void Death() {
        SceneManager.LoadScene("EndScreenLosing");
    }
}
