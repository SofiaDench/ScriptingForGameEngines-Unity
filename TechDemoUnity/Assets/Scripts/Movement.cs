using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //private Rigidbody rigidbody; comment: only needed if Intend to jump as the refenrece to the rigidbody will enable the physics (essential in 3D first person)
    private float horizontalInput;
    private float verticalInput;
    //private bool jumpInput; comment obsolete in a 3D top Down (essential in 3D first person)
    public float velocity;


    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();  Comment - obsolete in a 3D top Down (essential in 3D first person)
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); //gets comand for movement
        verticalInput = Input.GetAxis("Vertical"); // gets command for movement

        //Insert Jump input get key space here if using 3D first person
        Vector3 position = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(position * velocity * Time.deltaTime);


    }
}
