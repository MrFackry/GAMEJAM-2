using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class WinCondition : MonoBehaviour
{
    public GameObject menuWin;
    public int count;
    private bool isReadyDance = false;
    public GameObject robotComplete;
    private int danceDuration = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (count == 32)
        {
            isReadyDance = true;
            menuWin.SetActive(true);
        }
    }

    IEnumerator waitDance()
    {
        if (isReadyDance)
        {
            robotComplete.GetComponent<Animator>();
            yield return new WaitForSeconds(danceDuration);
        }
    }
}
