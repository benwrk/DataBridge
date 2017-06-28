using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class gameManager : MonoBehaviour {
    public RigidbodyFirstPersonController player;
    bool changeJump = false;


    // Use this for initialization
    void Start () {
        //player = GetComponent<RigidbodyFirstPersonController>();

    }
	
	// Update is called once per frame
	void Update () {
        bool ifMousePressed = Input.GetMouseButtonUp(1);

        if (ifMousePressed)
        {
            changeJump = !changeJump;
            player.movementSettings.JumpForce = 22;
        }
        if (changeJump)
        {
            player.movementSettings.JumpForce = 10;
        }
    }
}
