using System.Collections;
using TMPro;
using UnityEngine;

public class DropAndDrag : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    public bool isclic = false;
    public bool posV = false;
    private Vector3 initialPos;
    private AssemblyValidation assemblyValidation = null;
    private int part;
    private WinCondition winCondition;
    private void Start()
    {
        initialPos = gameObject.transform.position;
        assemblyValidation = FindAnyObjectByType<AssemblyValidation>();
        winCondition = FindFirstObjectByType<WinCondition>();
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
            part++;
            winCondition.count += part;
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
