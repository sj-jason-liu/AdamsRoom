using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Transform cameraTransform; // Reference to the camera transform

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Read input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;

        // Convert camera's forward direction to the character's local space
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0f; // Ignore vertical rotation

        // Rotate movement vector based on camera's forward direction
        movement = Quaternion.LookRotation(cameraForward) * movement;

        // Apply movement to the rigidbody
        rb.MovePosition(transform.position + movement);
    }
}
