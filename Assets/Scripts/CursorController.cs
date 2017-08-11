using UnityEngine;

/// <summary>
///     A controller for mouse cursor, designed to be attached to the EventSystem component.
/// </summary>
public class CursorController : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }
}
