using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Chaser : MonoBehaviour
{
    public Transform player; // Target player to chase
    public Camera camera;
    public float speed = 5f; // Speed at which the chaser moves towards the player
    public float increment = 0.1f;
    public float max = 10;
    public float min = 5;

    public float maxdistance = 10;
    public Color brightColor = Color.white;
    public Color darkcolor = Color.black;
    public int direction = 1;

    void Update()
    {
        if (player != null)
        {
            // Speed adjustment
            if (Input.GetKey(KeyCode.A))
            {
                speed = Mathf.Max(min, speed - increment * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                speed = Mathf.Min(max, speed + increment * 2 * Time.deltaTime);
            }
            else
            {
                speed = Mathf.Min(max, speed + increment * Time.deltaTime);
            }
            
            // Move towards the player
            transform.position += Vector3.right * direction * speed * Time.deltaTime;
        }
        
        // change the light color
        float distance = Vector3.Distance(transform.position, player.position);
        float t = distance / maxdistance;

        if (direction > 0)
        {
            t = Mathf.Min(t, 0.75f);
            camera.backgroundColor = Color.Lerp(darkcolor, brightColor, t);
        }
        else
        {
            camera.backgroundColor = Color.Lerp(darkcolor, brightColor, t);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
            // Implement game over logic here
        }
    }
    
    
    public void FlipDirection()
    {
        direction = -1;
    }
}