using System;
using UnityEngine;

public class AssemblyValidation : MonoBehaviour
{
    private GameObject PoitAssembly;
    private GameObject part;
    private string tag;
    private string tag2;

    void Start()
    {
        PoitAssembly = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Validation();
    }

    private void Validation()
    {
        if (PoitAssembly != null && part != null)
        {
            tag = PoitAssembly.tag;
            tag2 = part.tag;
            Debug.Log(tag + " " + tag2);
            if (tag == tag2)
            {
                Debug.Log("Unir");
            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        part = other.gameObject;
    }
}
