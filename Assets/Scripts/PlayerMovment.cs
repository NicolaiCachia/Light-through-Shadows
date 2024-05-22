using System;
using UnityEngine;


public class AutoMovePlayer : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float speedIncrement = 8f;
    public float minSpeed = 1f;
    public float maxSpeed = 25f;
    public float jumpForce = 700f; // Force applied upwards to perform a jump
    
    private Rigidbody2D rb;
    private bool isGrounded; // Whether or not the player is currently touching the ground

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Mathf.Clamp(moveSpeed, minSpeed, maxSpeed);
    }

    private void Update()
    {
        // Speed adjustment
        if (Input.GetKey(KeyCode.A))
        {
            moveSpeed = Mathf.Max(minSpeed, moveSpeed - speedIncrement * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveSpeed = Mathf.Min(maxSpeed, moveSpeed + speedIncrement * Time.deltaTime);
        }

        // Jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // Automatic movement to the right
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        Debug.Log(moveSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            isGrounded = true;

            
            
            if (Mathf.Abs(other.contacts[0].point.x - transform.position.x) > 0.4f && Mathf.Abs(other.contacts[0].point.y - transform.position.y) < 0.3f)
            {
                moveSpeed = minSpeed;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}