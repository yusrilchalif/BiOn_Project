using System.Runtime.InteropServices;
using UnityEngine;

public class TestPopUp : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void HelloString(string str);

    [SerializeField] string campusName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        print("Clicked" + campusName);
        HelloString(campusName);
    }
}