
using UnityEngine;

public class Character : MonoBehaviour
{
    public float moveSpeed = 5.0f; // player move speed
    public float jumpForce = 10.0f; // force of player jump
    
    private Rigidbody playerRb; // reference to the player's rigidbody
    private bool isGrounded = true; // flag to track if player is on the ground
    private bool isInteracting = false; // flag to track if player is interacting

    private void Start()
    {
        // get reference to the player's rigidbody
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // get input from the player's arrow keys or WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // calculate the player's movement direction based on input
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        // normalize the movement direction to prevent faster diagonal movement
        movementDirection.Normalize();

        // apply the movement to the player's rigidbody
        if (movementDirection != Vector3.zero) 
        {
            playerRb.velocity = new Vector3(movementDirection.x * moveSpeed, playerRb.velocity.y, movementDirection.z * moveSpeed);

        }
        else
        { //set the plpayers velocity to zero for idle
           playerRb.velocity = Vector3.zero;
        }

        // check if the player is on the ground
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, 0.1f);

        // allow the player to jump if they are on the ground
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // handle interacting
        if (Input.GetButtonDown("Interact"))
        {
            // check if there is an interactable object in front of the player
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f, interactLayer))
            {
                // call the Interact method on the object
                hit.collider.gameObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
                isInteracting = true;
            }
        }

        // reset the interacting flag if the player is no longer holding the interact button
        if (Input.GetButtonUp("Interact"))
        {
            isInteracting = false;
        }
    }
}
