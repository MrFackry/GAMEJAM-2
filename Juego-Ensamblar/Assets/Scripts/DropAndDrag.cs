using UnityEngine;

public class DropAndDrag : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    public bool isclic = false;
    private Vector3 initialPos;
    private AssemblyValidation assemblyValidation = null;
    public int count;
    private void Start()
    {
        initialPos = gameObject.transform.position;
        assemblyValidation = FindAnyObjectByType<AssemblyValidation>();
    }
    //detecta cuando se preciona el clic
    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - GetMouseWorldPos();
        isclic = true;
        assemblyValidation = null;
    }
    //detecta cuado se dega de precionar el clic
    private void OnMouseUp()
    {
        isclic = false;
        if (assemblyValidation != null && assemblyValidation.isCorectPlace)
        {
            transform.position = assemblyValidation.corectPos;
            enabled = false;
        }
        else
        {
            transform.position = initialPos;
        }
    }

    private void Update()
    {
        if (isclic)
        {
            MoveObjectWithMouse();
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void MoveObjectWithMouse()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    // Detecta si el objeto entra en un trigger de validación
    private void OnTriggerEnter(Collider other)
    {
        AssemblyValidation validation = other.GetComponent<AssemblyValidation>();
        if (validation != null && CompareTag(validation.targetTag)) // Compara la etiqueta de la parte con la etiqueta objetivo del lugar
        {
            assemblyValidation = validation;
            assemblyValidation.isCorectPlace = true;
            initialPos = assemblyValidation.corectPos;
            count++;
        }
    }

    // Detecta si el objeto sale de un trigger de validación
    private void OnTriggerExit(Collider other)
    {
        AssemblyValidation validation = other.GetComponent<AssemblyValidation>();
        if (validation != null && assemblyValidation == validation)
        {
            assemblyValidation.isCorectPlace = false;
            assemblyValidation = null;
        }
    }
}
