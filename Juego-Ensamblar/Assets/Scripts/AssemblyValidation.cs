using UnityEngine;

public class AssemblyValidation : MonoBehaviour
{
    public bool isCorectPlace = false;
    public string targetTag;
    public Vector3 corectPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        corectPos = transform.position;
        targetTag = gameObject.tag;
        if (string.IsNullOrEmpty(targetTag))
        {
            Debug.LogError("El objeto " + gameObject.name + " no tiene asignada una etiqueta objetivo (targetTag) en AssemblyValidation.");
        }
    }
}
