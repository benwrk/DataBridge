using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InputHandler : MonoBehaviour {

    string currentString;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void EndEditListener(string s)
    {
        currentString = s;
    }

    public void PassString(string neededString)
    {
        Debug.Log(currentString);
        currentString = null;
        EventSystem.current.SetSelectedGameObject(null);
    }



    //// Use this for initialization
    //private void Start()
    //{
    //    Cursor.visible = false;

    //}

    //private void ToggleFreezeOfPlayer()
    //{
    //    Controller.GetComponent<PlayerController>().ToggleFreeze();
    //    RbController.lookRotationEnabled = !RbController.lookRotationEnabled;
    //    if (Cursor.lockState == CursorLockMode.Locked)
    //    {
    //        Cursor.lockState = CursorLockMode.Confined;
    //        Debug.Log(Cursor.lockState);
    //    }
    //    else if (Cursor.lockState == CursorLockMode.Confined)
    //    {
    //        Cursor.lockState = CursorLockMode.Locked;
    //        Debug.Log(Cursor.lockState);
    //    }

    //    if (Cursor.visible)
    //    {
    //        Cursor.visible = false;
    //    }
    //    else if (!Cursor.visible)
    //    {
    //        Cursor.visible = true;
    //    }
    //}
}
