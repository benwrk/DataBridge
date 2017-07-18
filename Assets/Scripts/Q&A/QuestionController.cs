using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class QuestionController : MonoBehaviour {

    public GameObject Controller;
    public RigidbodyFirstPersonController RBController;



    // Use this for initialization
    void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ToggleFreezeOfPlayer()
    {
        Controller.GetComponent<PlayerController>().ToggleFreeze();
        RBController.lookRotationEnabled = !RBController.lookRotationEnabled;
        if (Cursor.lockState == CursorLockMode.Locked) { Cursor.lockState = CursorLockMode.Confined; Debug.Log(Cursor.lockState); }
        else if(Cursor.lockState == CursorLockMode.Confined) { Cursor.lockState = CursorLockMode.Locked; Debug.Log(Cursor.lockState); }
        if (Cursor.visible == true) { Cursor.visible = false; }
        else if (Cursor.visible == false) { Cursor.visible = true; }

    }
}
