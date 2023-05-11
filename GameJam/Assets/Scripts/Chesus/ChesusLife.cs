using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChesusLife : MonoBehaviour
{
    [SerializeField] GameObject healthBar;

    // Update is called once per frame
    void Update()
    {
        int hp = GetComponent<EnemyLife>().CurrentHp;
        int maxHp = GetComponent<EnemyLife>().maxHp;

        healthBar.GetComponent<HealthBar>().SetHealth(hp);
        healthBar.GetComponent<HealthBar>().SetMaxHealth(maxHp);
    }
}
