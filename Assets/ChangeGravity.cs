using UnityEngine;
using System.Collections;
// we use firstPerson controller from standar assets
using UnityStandardAssets.Characters.FirstPerson;
public class ChangeGravity : MonoBehaviour
{
    //we create the variable so we can acces FirstPersonController script 
    FirstPersonController FPScontroller;
    // Use this for initialization
    void Start()
    {
       // Physics.gravity = new Vector3(0, -1, 0);
        FPScontroller = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Physics.gravity = Vector3.up * 0.1f;
            //we stop all movement from FPSController
           FPScontroller.m_MoveDir = Vector3.zero;
            // we remove stick to ground force wich was the force keeping us in ground untill we jumped
            FPScontroller.m_StickToGroundForce = 0;

        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Physics.gravity = Vector3.down * 0.1f;
            //we restore m_StickToGroundForce so we can walk on ground again
            FPScontroller.m_StickToGroundForce = 10;
            //we stop all movement from FPSController
            FPScontroller.m_MoveDir = Vector3.zero;
        }

    }
}
