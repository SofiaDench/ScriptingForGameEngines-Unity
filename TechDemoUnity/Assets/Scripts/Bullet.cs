using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed; // bullet speed variable
    public float bulletDamage; // bullet damage variable
    public float bulletTime;

    void Start()
    {
        Destroy(gameObject, bulletTime); // destroy bullet after 5 seconds
    }

    void Update()
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime); // move the bullet forward
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) // if bullet hits an enemy
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage); // call enemy's TakeDamage method
            Destroy(gameObject); // destroy the bullet
        }
        else if (!other.gameObject.CompareTag("Player")) // if bullet hits something else
        {
            Destroy(gameObject); // destroy the bullet
        }
    }
}
