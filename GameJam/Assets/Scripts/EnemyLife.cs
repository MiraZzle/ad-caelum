using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {
    [SerializeField] public int maxHp;
    public int CurrentHp;
    private SimpleFlash simpleFlash;
    GameObject logicManager;
    LevelLogic logicScript;

    void Start() {
        CurrentHp = maxHp;
        simpleFlash = gameObject.GetComponent<SimpleFlash>();
        logicManager = GameObject.FindGameObjectWithTag("Logic");
        logicScript = logicManager. GetComponent<LevelLogic>();
    }

    public void TakeDamage(int damage) {

        CurrentHp -= damage;
        if (CurrentHp <= 0) {
            Destroy(gameObject);
            logicScript.killedEnemies += 1;
        }
        simpleFlash.Flash();
    }
}
