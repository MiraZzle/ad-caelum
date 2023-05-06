using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int minHealth = 0;
    public int currHealth;

    public HealthBar healthBar;
    public Fade fade;

    void Start()
    {
        currHealth = maxHealth;
        healthBar.setup (maxHealth);
        fade.setupFade(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int dmg)
    {
        currHealth -= dmg;
        if (currHealth < minHealth)
        {
            currHealth = minHealth; 
        }
        healthBar.setHealth(currHealth);
        fade.setHealthFade(currHealth);
    }

}
