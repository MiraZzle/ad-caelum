using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int hp = 0;
    GameObject logicManager;
    LevelLogic logicScript;

    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic");
        logicScript = logicManager. GetComponent<LevelLogic>();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
            logicScript.killedEnemies += 1;
        }
    }
}
