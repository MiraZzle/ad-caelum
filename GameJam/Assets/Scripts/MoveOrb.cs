using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOrb : MonoBehaviour
{
    [SerializeField] GameObject chesus;
    [SerializeField] float radius = 3f;
    [SerializeField] float loopTime = 2f;
    [SerializeField] float angle = 0f;
    int damage = 1;

    
    void Start()
    {
        
    }

    void Update()
    {
        angle = (angle + Time.deltaTime * 360) % 360;

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
