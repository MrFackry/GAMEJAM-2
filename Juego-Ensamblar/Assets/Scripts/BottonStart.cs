using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonStart : MonoBehaviour

{
    
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
