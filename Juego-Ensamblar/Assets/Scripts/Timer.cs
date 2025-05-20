using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class Timer : MonoBehaviour
{
    public float timer = 0f;
    public Text timerText;
    public bool shouldStart;
    void Start()
    {
        shouldStart = false;

    }

    void Update()
    {
        OnMouseDown();
        if (shouldStart)
        {
            timer -= Time.deltaTime;
            timerText.text = "" + timer.ToString("f1");
        }
        if (timer < 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    void OnMouseDown()
    {
        shouldStart = true;
        Debug.Log("click ativa timmer");
    }
}
