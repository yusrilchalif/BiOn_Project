using UnityEngine;

public class DragRotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 3f; // Rotation speed per click/drag
    [SerializeField] private float maxRotationZ = 45f; // Maximum allowed rotation on Z-axis
    [SerializeField] private float movementSpeed = 1f; // Speed of horizontal movement per frame
    [SerializeField] private float timerInterval = 1f; // Time interval for automatic Z-axis rotation

    private Vector3 startClickPosition; // Stores initial mouse position on click
    private bool isDragging = false; // Flag to indicate if dragging is active
    private float currentRotationZ = 0f; // Tracks the cumulative rotation on Z-axis
    private float timer = 0f; // Timer for automatic Z-axis rotation
    private bool isRotatingPositive = true; // Flag to track rotation direction

    void Update()
    {
        // Handle left mouse button click and dragging for rotation
        if (Input.GetMouseButtonDown(0) && !isDragging)
        {
            startClickPosition = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 deltaMousePosition = Input.mousePosition - startClickPosition;
            float rotationZ = deltaMousePosition.x * rotationSpeed * Time.deltaTime;

            float newRotationZ = currentRotationZ + rotationZ;
            newRotationZ = Mathf.Clamp(newRotationZ, -maxRotationZ, maxRotationZ);

            float actualRotationZ = newRotationZ - currentRotationZ;
            transform.Rotate(0f, 0f, actualRotationZ);

            currentRotationZ = newRotationZ;
            startClickPosition = Input.mousePosition;
        }

        //RotateObjectWorld();
    }

    void RotateObjectWorld()
    {
        // Add smooth horizontal movement within rotation limits
        float targetRotationZ = transform.localEulerAngles.z; // Get current Z-axis rotation
        float targetPositionX = Mathf.Clamp(targetRotationZ / maxRotationZ, -1f, 1f) * movementSpeed; // Calculate target X position based on rotation

        // Smoothly lerp towards the target X position for a natural movement effect
        float newPositionX = Mathf.Lerp(transform.localPosition.x, targetPositionX, Time.deltaTime * 5f); // Adjust lerp speed as needed
        transform.localPosition = new Vector3(newPositionX, transform.localPosition.y, transform.localPosition.z);

        // Automatic Z-axis rotation every timerInterval
        timer += Time.deltaTime;
        if (timer >= timerInterval)
        {
            float automaticRotationZ = 0f;

            if (isRotatingPositive)
            {
                automaticRotationZ = Mathf.Min(currentRotationZ + 1f, maxRotationZ); // Rotate towards maxRotationZ

                if (automaticRotationZ == maxRotationZ)
                {
                    isRotatingPositive = false; // Change direction once maxRotationZ is reached
                }
            }
            else
            {
                automaticRotationZ = Mathf.Max(currentRotationZ - 1f, -maxRotationZ); // Rotate towards -maxRotationZ

                if (automaticRotationZ == -maxRotationZ)
                {
                    isRotatingPositive = true; // Change direction once -maxRotationZ is reached
                }
            }

            transform.Rotate(0f, 0f, automaticRotationZ - currentRotationZ);
            currentRotationZ = automaticRotationZ;

            timer = 0f; // Reset timer
        }
    }
}
