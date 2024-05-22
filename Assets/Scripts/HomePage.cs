using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver  : MonoBehaviour
{
    public void HomeScene()
    {
        
        SceneManager.LoadScene("HomeScene"); //send me to home
    }
}
