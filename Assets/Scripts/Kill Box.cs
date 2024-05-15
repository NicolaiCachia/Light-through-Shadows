using System.Collections;
using System.Collections.Generic;
using UnityEngine. SceneManagement;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
            // Implement game over logic here
        }
    }
}
