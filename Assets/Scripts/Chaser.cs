using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    public Transform player; // Target player to chase
    public float speed = 5f; // Speed at which the chaser moves towards the player

    void Update()
    {
        if (player != null)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the chaser has collided with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // End the game
            Debug.Log("Game Over!");
            // Here you would typically call a method to handle the end of the game,
            // such as displaying a game over screen or restarting the level
        }
    }
}

public class Chaser : MonoBehaviour
{
    public Transform player; // Target player to chase
    private Rigidbody2D playerRb; // Rigidbody of the player
    private Rigidbody2D rb; // Rigidbody of the chaser
    public float speedMultiplier = 1.0f; // Multiplier to adjust speed slightly if needed

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (player != null) {
            playerRb = player.GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (playerRb != null)
        {
            // Move towards the player at the player's current speed
            float speed = playerRb.velocity.magnitude * speedMultiplier;
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over!");
            // Implement game over logic here
        }
    }
}

