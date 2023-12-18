using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;

    public Transform playerTransform; // Reference to the player's transform

    private Rigidbody rb;
    private bool isGrounded;

    // Smoothing parameters
    public float smoothSpeed = 5.0f;
    public Vector3 offset;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the player is grounded.
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // Movement controls using arrow keys.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        if (moveDirection != Vector3.zero)
        {
            // Rotate the character to face the direction of movement.
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        // Jumping with the space bar when grounded.
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collided with a key
        if (other.CompareTag("Key"))
        {
            // Get the Key component from the collided GameObject
            Key key = other.GetComponent<Key>();

            // Check if the Key component exists
            if (key != null)
            {
                // Call the CollectKey method of the Key component
                key.CollectKey();
            }
        }
    }

    void FixedUpdate()
    {
        // Apply movement using Rigidbody.MovePosition in FixedUpdate.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;
        Vector3 movement = moveDirection * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);

        // Null check for playerTransform
        if (playerTransform != null)
        {
            // Smoothly follow the player with the camera
            Vector3 desiredPosition = playerTransform.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        else
        {
            Debug.LogWarning("Player Transform is not assigned. Please assign it in the Inspector.");
        }
    }
}
