using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChesusLife : MonoBehaviour
{
    [SerializeField] GameObject healthBar;

    void Start()
    {
        int hp = GetComponent<EnemyLife>().hp;
        healthBar.GetComponent<HealthBar>().SetMaxHealth(hp);
    }

    // Update is called once per frame
    void Update()
    {
        int hp = GetComponent<EnemyLife>().hp;
        healthBar.GetComponent<HealthBar>().SetHealth(hp);
    }
}
