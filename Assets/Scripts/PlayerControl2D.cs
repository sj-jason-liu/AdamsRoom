using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2D : MonoBehaviour
{
    public float moveSpeed = 5f;  // The speed at which the player moves
    public float jumpForce = 5f;  // The force applied to make the player jump
    public float gravity = -9.81f;  // The gravity applied to the player

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Player movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        movement = transform.TransformDirection(movement);
        movement *= moveSpeed;

        // Player jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            playerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(movement * Time.deltaTime);
        controller.Move(playerVelocity * Time.deltaTime);

        // Check if the player is grounded
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0f)
        {
            playerVelocity.y = 0f;
        }
    }
}
