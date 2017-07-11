using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class OpenTheDoor : MonoBehaviour
{
    public GameObject rollingDoor;
    private DoorState doorState = DoorState.Closed;
    private enum DoorState
    {
        Opened,
        Opening,
        Closed,
        Closing
    }

    void OnTriggerEnter(Collider GameObj)
    {
        //  if (GameObj.GetComponent<Rigidbody>() == GetComponent<RigidbodyFirstPersonController>().m_RigidBody)
        //   {
        //  Debug.
        //var animator = rollingDoor.GetComponent<Animator>();
       // if (doorState == DoorState.Closed)
       // {
            rollingDoor.GetComponent<Animator>().Play("Rolling Door Open");
        //    doorState = DoorState.Opening;
       // }

        //   }
    }

    void OnTriggerStay()
    {
        // rollingDoor.GetComponent<Animator>().Play("Rolling Door Open State");
    }




    void OnTriggerExit()
    {
        rollingDoor.GetComponent<Animator>().Play("Rolling Door Close");
    }




}
