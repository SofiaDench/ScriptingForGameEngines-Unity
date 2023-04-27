using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpin : MonoBehaviour //Coin Spinning solution
{
    private Rigidbody rb;
    public float spinForce = 10f;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // void Update()
    //{
    //      rb.AddTorque(transform.up * spinForce);
    // }

    void OnCollisionEnter(Collision collision)
    {
        // Get the normal of the collision contact point
        Vector3 contactNormal = collision.GetContact(0).normal;

        // Calculate the torque direction using the contact normal
        Vector3 torqueDirection = Vector3.Cross(contactNormal, Vector3.up).normalized;

        // Apply torque to the Rigidbody around the torque direction
        rb.AddTorque(torqueDirection * spinForce);
    }
}
