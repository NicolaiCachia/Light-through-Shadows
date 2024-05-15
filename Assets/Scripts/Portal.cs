using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Chaser chaser;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            chaser.FlipDirection();
            // research coroutines! (start wait change sene)
        }
    }
    
}
