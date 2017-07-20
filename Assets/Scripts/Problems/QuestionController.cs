using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class QuestionController : MonoBehaviour
{
    public GameObject Controller;
    public RigidbodyFirstPersonController RbController;

    
    // Use this for initialization
    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame

    private void ToggleFreezeOfPlayer()
    {
        Controller.GetComponent<PlayerController>().ToggleFreeze();
        RbController.lookRotationEnabled = !RbController.lookRotationEnabled;
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Confined; Debug.Log(Cursor.lockState);
        }
        else if (Cursor.lockState == CursorLockMode.Confined)
        {
            Cursor.lockState = CursorLockMode.Locked; Debug.Log(Cursor.lockState);
        }

        if (Cursor.visible)
        {
            Cursor.visible = false;
        }
        else if (!Cursor.visible)
        {
            Cursor.visible = true;
        }

    }
}
