using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 100f;
    public float rotationSmoothing = 10f; // Smoothing factor for rotation

    private Quaternion targetRotation; // Target rotation for smoothing

    private void Start()
    {
        targetRotation = transform.localRotation;
    }

    private void Update()
    {
        // Read input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;

        // Apply movement to local position
        transform.localPosition += transform.TransformDirection(movement);

        // Rotate character based on mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float rotationAmount = mouseX * rotationSpeed * Time.deltaTime;

        // Update target rotation for smoothing
        targetRotation *= Quaternion.Euler(0f, rotationAmount, 0f);

        // Smoothly rotate character towards the target rotation
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSmoothing * Time.deltaTime);
    }
}
