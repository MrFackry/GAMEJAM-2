using UnityEngine;

public class AssemblyValidation : MonoBehaviour
{
    public bool isCorectPlace = false;
    string tag1;
    string tag2;
    public Vector3 corectPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tag1 = gameObject.tag;
        Debug.Log(tag1);
        corectPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        tag2 = other.gameObject.tag;
        if (tag1 == tag2)
        {
            isCorectPlace = true;
        }
    }
}
