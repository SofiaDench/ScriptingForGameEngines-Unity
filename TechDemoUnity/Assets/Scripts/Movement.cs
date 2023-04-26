using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // movement speed

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // get horizontal input
        float vertical = Input.GetAxis("Vertical"); // get vertical input

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; // create direction vector
        Vector3 velocity = direction * speed; // calculate velocity

        transform.position += velocity * Time.deltaTime; // move the character
    }
}

