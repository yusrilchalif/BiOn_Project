using UnityEngine;

public class ScrollZoom : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 10f;  // Speed of zooming in
    [SerializeField] private float minZoom = 0f;    // Minimum field of view
    [SerializeField] private float maxZoom = 60f;    // Maximum field of view (if you decide to use it)

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            Debug.LogError("Camera component not found!");
        }
    }

    void Update()
    {
        if (cam != null)
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            if (scrollInput != 0f) // Only zoom in
            {
                float newFOV = cam.fieldOfView - scrollInput * zoomSpeed;
                cam.fieldOfView = Mathf.Clamp(newFOV, minZoom, maxZoom);
            }
        }
    }
}
