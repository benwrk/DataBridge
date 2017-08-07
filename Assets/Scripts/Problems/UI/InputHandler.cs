using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InputHandler : MonoBehaviour {

    List<string> _currentString;

    private void Awake()
    {
        
        _currentString = new List<string>();
    }

    public void EndEditListener(string s)
    {
        if (s != "")
            _currentString.Add(s);
    }

    public void OnSubmit()
    {
        EventSystem.current.SetSelectedGameObject(null);
        PassStringToVerify();
        
      //  _currentString = null;
    }

    public /*List<string>*/ void PassStringToVerify()
    {
        // TODO call verifier 
        Debug.Log(_currentString[0] + _currentString[1]);
       // return _currentString;
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
