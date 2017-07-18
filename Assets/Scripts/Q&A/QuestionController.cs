using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class QuestionController : MonoBehaviour {

    public GameObject Controller;
    public RigidbodyFirstPersonController RBController;



    // Use this for initialization
    void Start () {
        ToggleFreezeOfPlayer();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ToggleFreezeOfPlayer()
    {
        Controller.GetComponent<PlayerController>().ToggleFreeze();
        RBController.lookRotationEnabled = !RBController.lookRotationEnabled;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }








}
