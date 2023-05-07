using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {
    [SerializeField] public int hp = 0;
    private SimpleFlash simpleFlash;
    GameObject logicManager;
    LevelLogic logicScript;

    void Start() {
        simpleFlash = gameObject.GetComponent<SimpleFlash>();
        logicManager = GameObject.FindGameObjectWithTag("Logic");
        logicScript = logicManager. GetComponent<LevelLogic>();
    }

    public void TakeDamage(int damage) {

        hp -= damage;
        if (hp <= 0) {
            Destroy(gameObject);
            logicScript.killedEnemies += 1;
        }
        simpleFlash.Flash();
    }
}
