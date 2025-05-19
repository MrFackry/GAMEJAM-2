using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
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
