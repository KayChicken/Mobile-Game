using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Rigidbody rb;
    public int damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * 30;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy target = other.GetComponent<Enemy>();
        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }


}
