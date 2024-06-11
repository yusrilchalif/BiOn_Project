using UnityEngine;
using UnityEngine.UI;

public class ScrollZoom : MonoBehaviour
{
    [SerializeField] private float zoomSpeed = 10f;  // Speed of zooming in
    [SerializeField] private float minZoom = 0f;    // Minimum field of view
    [SerializeField] private float maxZoom = 60f;    // Maximum field of view (if you decide to use it)

    [SerializeField] Button zoomInCamera;
    [SerializeField] Button zoomOutCamera;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        zoomInCamera.onClick.AddListener(ZoomIn);
        zoomOutCamera.onClick.AddListener(ZoomOut);
    }

    void Update()
    {
        if (cam != null)
        {
            // Zoom using mouse scroll wheel
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            if (scrollInput != 0f)
            {
                float newFOV = cam.fieldOfView - scrollInput * zoomSpeed;
                cam.fieldOfView = Mathf.Clamp(newFOV, minZoom, maxZoom);
            }
        }
    }

    public void ZoomIn()
    {
        if (cam != null)
        {
            float newFOV = cam.fieldOfView - 100.0f * Time.deltaTime;
            cam.fieldOfView = Mathf.Clamp(newFOV, minZoom, maxZoom);
        }
    }

    public void ZoomOut()
    {
        if (cam != null)
        {
            float newFOV = cam.fieldOfView + 100.0f * Time.deltaTime;
            cam.fieldOfView = Mathf.Clamp(newFOV, minZoom, maxZoom);
        }
    }

    //bool IsPointerOverUIElement()
    //{
    //    if (EventSystem.current.IsPointerOverGameObject())
    //    {
    //        return true;
    //    }
    //    return false;
    //}
}
