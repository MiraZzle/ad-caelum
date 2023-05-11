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

        if (hp <= 0)
        {
            foreach (GameObject angel in GetComponent<ChesusSpawn>().spawnedAngels)
            {
                if (angel == null) continue;
                EnemyLife angelLife = angel.GetComponent<EnemyLife>();  
                angelLife.TakeDamage(angelLife.CurrentHp);
            }
            Destroy(gameObject);
        }
    }
}
