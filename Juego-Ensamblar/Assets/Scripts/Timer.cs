using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
public class Timer : MonoBehaviour
{
    public float timer = 0f;
    public Text timerText;
    private DropAndDrag dropAndDrag;
    public bool shouldStart;
    void Start()
    {

        dropAndDrag = FindFirstObjectByType<DropAndDrag>();
        shouldStart = false;
        

    }
   
    void Update()
    {
        if (dropAndDrag.isclic)
        {
            shouldStart = true;
        }
       
        if (shouldStart)
        {
            timer -= Time.deltaTime;
            timerText.text = "" + timer.ToString("f1");
        }
      if (timer < 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
