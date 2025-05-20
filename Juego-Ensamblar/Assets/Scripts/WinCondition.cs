using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class WinCondition : MonoBehaviour
{
    public GameObject menuWin;
    public Camera fCamera;
    public GameObject levelMenu;
    public int count;
    public bool isReadyDance = false;
    public GameObject robotComplete;
    private int danceDuration = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 31)
        {
            isReadyDance = true;
            menuWin.SetActive(true);
            levelMenu.SetActive(false);
            fCamera.transform.position = new Vector3(0f,38.09f, -9.4f);
            StartCoroutine(waitDance());
        }
    }

    IEnumerator waitDance()
    {
        if (isReadyDance)
        {
            robotComplete.SetActive(true);
            yield return new WaitForSeconds(danceDuration);
            Time.timeScale = 0;
        }
    }
}
