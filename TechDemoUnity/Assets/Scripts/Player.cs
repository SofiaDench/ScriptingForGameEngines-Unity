using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables

    public float movementSpeed;
    public GameObject camera;

    public Transform playerObject;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public float waitTime;

    private Transform bulletSpawned;

    public float points;

    public float maxHealth;
    public float health;


    //Methods

    private void Start()
    {
        health = maxHealth;
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


        //Player Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }

        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        //Player Death

        if (health <= 0)
        {
            Die();
        }


    }//end of void Update

    void Shoot()
    {
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
    }
    public void Die()
    {
        print("You are dead");
    }



}





