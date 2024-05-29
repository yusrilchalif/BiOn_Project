using UnityEngine;

public class DragRotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 3f; // Rotation speed per click/drag
    [SerializeField] private float maxRotationZ = 45f; // Maximum allowed rotation on Z-axis

    private Vector3 startClickPosition; // Stores initial mouse position on click
    private bool isDragging = false;    // Flag to indicate if dragging is active
    private float currentRotationZ = 0f; // Tracks the cumulative rotation on Z-axis

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDragging) // Left mouse button click and not dragging
        {
            startClickPosition = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && isDragging) // Left mouse button released and dragging
        {
            isDragging = false;
        }

        if (isDragging) // Drag operation
        {
            Vector3 deltaMousePosition = Input.mousePosition - startClickPosition;

            // Calculate rotation based on mouse movement
            float rotationZ = deltaMousePosition.x * rotationSpeed * Time.deltaTime;

            // Calculate new potential rotation value
            float newRotationZ = currentRotationZ + rotationZ;

            // Clamp the rotation to the specified max limits
            newRotationZ = Mathf.Clamp(newRotationZ, -maxRotationZ, maxRotationZ);

            // Apply the difference to the current rotation to get the actual rotation step
            float actualRotationZ = newRotationZ - currentRotationZ;

            // Apply the rotation
            transform.Rotate(0f, 0f, actualRotationZ);

            // Update the current rotation value
            currentRotationZ = newRotationZ;

            // Update start position for next drag
            startClickPosition = Input.mousePosition;
        }
    }

}
