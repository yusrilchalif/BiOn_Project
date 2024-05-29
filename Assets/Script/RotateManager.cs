using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{
    public List<GameObject> rotateObject;
    public float speedRotate;
    public Vector3 rotate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject gameObject in rotateObject)
        {
            gameObject.transform.Rotate(rotate * speedRotate * Time.deltaTime);
        }
    }
}
