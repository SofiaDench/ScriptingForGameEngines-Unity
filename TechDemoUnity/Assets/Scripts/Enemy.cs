using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f; // enemy health

    private Transform target;
    public Collider patrolArea;

    public float attackRadius;

    public float moveSpeed;

    private Vector3 patrolDirection;
    public float patrolTimer;
    public float patrolTime;
    public float enemyDamage;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        ChoosePatrolDirection();
    }


    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        //Debug.Log(distanceToTarget);

        if(distanceToTarget < attackRadius)
        {
            Attack();
        }
        else
        {
            Patrol();
        }


        
    }

    private void Attack()
    {
        Vector3 targetDirection = (target.transform.position - transform.position).normalized;
        transform.position += targetDirection * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(enemyDamage);
        }

            
    }

    void Patrol()
    {
        transform.position += patrolDirection * moveSpeed * Time.deltaTime;

        // Update patrol timer
        patrolTimer -= Time.deltaTime;
        if (patrolTimer <= 0.0f)
        {
            // Choose a new patrol direction
            ChoosePatrolDirection();
        }
    }

    //enemy starting patrol points within a collider box
    public Vector3 RandomPointInArea(Bounds bounds)
    {
        return new Vector3(Random.Range(bounds.min.x, bounds.max.x), 1.0f, Random.Range(bounds.min.z, bounds.max.z));
    }


    void ChoosePatrolDirection()
    {
        Bounds bounds = patrolArea.GetComponent<Collider>().bounds;
        Vector3 randomPoint;
        do
        {
            randomPoint = RandomPointInArea(bounds);
        } while (!bounds.Contains(randomPoint)); // Keep generating new points until a point within the bounds is found
        patrolDirection = (randomPoint - transform.position).normalized;
        patrolTimer = patrolTime;
    }



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



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

}

