using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float horizontalMovement;
    float verticalMovement;
    bool jumpInput;



    public float moveSpeed;
    public float jumpForce;

    //Variables

    private Rigidbody rb;

    public Transform playerObject;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;

    private Transform bulletSpawned;

    public float health;
    public HealthBar healthBar;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        healthBar.SetMaxHealth((int)health);
    }


    void Update()
    {
        //Player facing mouse
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);

        float histDist = 0.0f;

        if (playerPlane.Raycast(ray, out histDist))
        {
            Vector3 targetPoint = ray.GetPoint(histDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;

            playerObject.transform.rotation = Quaternion.Slerp(playerObject.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }

        Move();

        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
    }

    public void Move()
    {

        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontalMovement, 0.0f, verticalMovement) * moveSpeed * Time.deltaTime;

        // Move the character
        transform.position += moveDirection;

        // Check for jump input
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            // Apply upward force for jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
        }
    }

    public void TakeDamage(float damage)
    {

        
        health -= damage; // reduce health by damage

        healthBar.SetHealth((int)health);


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





