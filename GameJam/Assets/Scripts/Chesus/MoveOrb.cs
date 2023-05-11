using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOrb : MonoBehaviour
{
    [SerializeField] GameObject chesus;
    float radius = 2f;
    float loopTime = 1f;
    [SerializeField] float angle = 0f;
    int damage = 1;

    
    void Start()
    {
        
    }

    void Update()
    {
        angle = (angle + Time.deltaTime / loopTime * 360) % 360;

        transform.position = chesus.transform.position + new Vector3(
            Mathf.Cos(Mathf.Deg2Rad * angle) * radius,
            Mathf.Sin(Mathf.Deg2Rad * angle) * radius,
            0
            );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLife>().TakeDamage(damage);
        }
    }
}
