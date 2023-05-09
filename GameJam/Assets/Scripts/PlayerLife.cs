using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {
    [SerializeField] public int maxHp;
    public int currentHp;
    public bool isAlive = true;
    private SimpleFlash simpleFlash;
    private Animator anim;
    GameObject trident;
    [SerializeField] GameObject healthBar;

    void Start() 
    {
        currentHp = maxHp;
        simpleFlash = gameObject.GetComponent<SimpleFlash>();
        trident = GameObject.FindGameObjectWithTag("trident");
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        healthBar.GetComponent<HealthBar>().SetHealth(currentHp);
        healthBar.GetComponent<HealthBar>().SetMaxHealth(maxHp);
    }
    public void TakeDamage(int damage) 
    {
        currentHp -= damage;

        if (currentHp <= 0) 
        {
            isAlive = false;
            Destroy(trident);
            anim.SetBool("isDeat", true);  // this is not a typo, the variable is reall named like this
            Invoke("Death", 2f);
        } 
        else 
        {
            simpleFlash.Flash();
        }
    }

    void Death() 
    {
        SceneManager.LoadScene("EndScreenLosing");
    }
}
