using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundMask;
    public float gravity = 9.81f;
    private float verticalVelocity = 0.0f;
    public float speed = 5.0f;
    public float jumpSpeed = 5.0f;
    private CharacterController controller;
    private bool isGrounded = false;
    public float groundCheckDistance = 0.1f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void UpdateGroundCheck()
{
    // Cast a ray from player's feet to the ground to check if there is a ground surface
    RaycastHit hit;
    if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundMask))
    {
        isGrounded = true;
    }
    else
    {
        isGrounded = false;
    }
}

    void Update()
    {
         // Update ground check
        UpdateGroundCheck();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (controller.isGrounded)
    {
        // Apply gravity to reset vertical velocity
        verticalVelocity = -gravity * Time.deltaTime;

        // Check if the player wants to jump
        if (Input.GetButtonDown("Jump"))
        {
            // Apply jump speed to vertical velocity
            verticalVelocity = jumpSpeed;
        }
    }
    else
    {
        // Apply gravity
        verticalVelocity -= gravity * Time.deltaTime;
    }
        Vector3 direction = new Vector3(horizontal, verticalVelocity, vertical);
        controller.Move(direction * Time.deltaTime);
        direction = transform.TransformDirection(direction);
        direction *= speed;

        controller.Move(direction * Time.deltaTime);

}
}
