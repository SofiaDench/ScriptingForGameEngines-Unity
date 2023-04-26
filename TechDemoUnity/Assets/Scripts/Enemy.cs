using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f; // enemy health

    public void TakeDamage(float damage)
    {
        health -= damage; // reduce health by damage
        if (health <= 0)
        {
            Die(); // if health is <= 0, call the Die method
        }
    }

    void Die()
    {
        Destroy(gameObject); // destroy the enemy object
    }
}

