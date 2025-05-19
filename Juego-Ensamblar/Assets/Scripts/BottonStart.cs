using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonStart : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
