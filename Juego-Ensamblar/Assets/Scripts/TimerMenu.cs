using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerMenu : MonoBehaviour
{
    public float timer= 0f;
    public Text timerText;
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "" + timer.ToString("f1");

        if (timer < 0)
        {
            SceneManager.LoadScene(3);
   
        }
        
    }
}
