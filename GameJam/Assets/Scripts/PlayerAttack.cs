using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform firePosition;
    [SerializeField] GameObject projectile;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, firePosition.position, firePosition.rotation); 
        }
    }
}
