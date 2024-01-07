using UnityEngine;

public class RotatePrefab : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 dragStartPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnMouseUp();
        }
        else if (isDragging)
        {
            OnMouseDrag();
        }
    }

    void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            isDragging = true;
            dragStartPosition = Input.mousePosition;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void OnMouseDrag()
    {
        Vector3 dragCurrentPosition = Input.mousePosition;
        Vector3 difference = dragCurrentPosition - dragStartPosition;

        // Adjust the rotation speed based on your preference
        float rotationSpeed = 0.5f;

        // Only rotate around the Y-axis
        float yaw = -difference.x * rotationSpeed;

        // Apply rotation to the prefab
        transform.Rotate(Vector3.up, yaw, Space.World);

        // Update the drag start position for the next frame
        dragStartPosition = dragCurrentPosition;
    }
}
