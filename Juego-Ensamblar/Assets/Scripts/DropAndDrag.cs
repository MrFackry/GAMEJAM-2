using UnityEngine;

public class DropAndDrag : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;
    public bool isClic = false;
    public int count = 0;

    private void Start()
    {
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;//obtenemos la pocison real del objeto a un plano 2d teniendo en cuenta la distancia con el eje z
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClic = !isClic; // Cambia entre mover y no mover
        }

        if (isClic)
        {
            MoveObjectWithMouse();
        }
    }
    //metodo para mover el objeto
    private void MoveObjectWithMouse()
    {
        Vector3 mousePoint = Input.mousePosition;//obtenemos x y 
        mousePoint.z = zCoord;//asignamos z
        transform.position = Camera.main.ScreenToWorldPoint(mousePoint) + offset;//movemos el objeto
    }
}
