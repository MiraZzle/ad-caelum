using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkAttack : MonoBehaviour
{
    public bool krucifixDestroyed;
    [SerializeField] GameObject projectile;
    private void Start()
    {
        krucifixDestroyed = false;
    }
    private void Update()
    {
        if (krucifixDestroyed)
        {
            //Destroy(gameObject);
            Instantiate(projectile, transform.position, Quaternion.identity);
            krucifixDestroyed = false;
        }
    }

}
