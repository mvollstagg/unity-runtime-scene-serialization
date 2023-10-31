using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed.

    private Rigidbody rb;
    private Vector3 movementInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component.
    }

    private void Update()
    {
        // Get input from the keyboard.
        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.z = Input.GetAxis("Vertical");
        movementInput.Normalize(); // This ensures consistent movement speed in all directions.
    }

    private void FixedUpdate()
    {
        // Move the cube using the Rigidbody for physics calculations.
        rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
    }
}
