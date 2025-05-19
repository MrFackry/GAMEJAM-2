using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameObject bottonPause;
    [SerializeField] private GameObject menuPause;
    
    public void Pause()
    {
        Time.timeScale = 0f;
        bottonPause.SetActive(false);
        menuPause.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        bottonPause.SetActive(true);
        menuPause.SetActive(false);
    }
    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        bottonPause.SetActive(true);
        menuPause.SetActive(false);
    }

}
