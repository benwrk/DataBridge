using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
