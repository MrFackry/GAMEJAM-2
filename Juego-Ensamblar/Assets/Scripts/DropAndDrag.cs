using UnityEngine;

public class DropAndDrag : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    private bool isclic = false;
    private Vector3 initialPos;
    private AssemblyValidation assemblyValidation;
    private void Start()
    {
        initialPos = gameObject.transform.position;
        assemblyValidation = FindFirstObjectByType<AssemblyValidation>();
    }
    //detecta cuando se preciona el clic
    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - GetMouseWorldPos();
        isclic = true;
    }
    //detecta cuado se dega de precionar el clic
    private void OnMouseUp()
    {
        isclic = false;
        if (!assemblyValidation.isCorectPlace)
        {
           gameObject.transform.position = initialPos; 
        }else
        {
            gameObject.transform.position = assemblyValidation.corectPos;
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
}
