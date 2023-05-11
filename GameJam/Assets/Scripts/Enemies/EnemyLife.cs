using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {
    [SerializeField] public int maxHp;
    [SerializeField] private bool isBoss = false;
    public int CurrentHp;
    private SimpleFlash simpleFlash;
    GameObject logicManager;
    LevelLogic logicScript;
    EnemyMove movement;

    void Start() {
        CurrentHp = maxHp;
        simpleFlash = gameObject.GetComponent<SimpleFlash>();
        logicManager = GameObject.FindGameObjectWithTag("Logic");
        logicScript = logicManager. GetComponent<LevelLogic>();
        movement = GetComponent<EnemyMove>();
    }

    public void TakeDamage(int damage) {
        CurrentHp -= damage;
        if (CurrentHp <= 0)
        { 
            logicScript.killedEnemies += 1;
            if (!isBoss)
            {
                Destroy(gameObject);
            }
        }
        simpleFlash.Flash();

        movement.aipath.canMove = true;

    }
}
