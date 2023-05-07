using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int hp = 20;
    public bool isALive = true;
    void Start()
    {

    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            isALive = false;
            SceneManager.LoadScene("EndScreenLosing");
        }
    }
}