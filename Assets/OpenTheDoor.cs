using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class OpenTheDoor : MonoBehaviour
{
    public GameObject rollingDoor;
    
    void OnTriggerEnter(Collider GameObj)
    {
        //  if (GameObj.GetComponent<Rigidbody>() == GetComponent<RigidbodyFirstPersonController>().m_RigidBody)
        rollingDoor.GetComponent<Animator>().SetBool("isOpen", true);
    }


    void OnTriggerExit()
    {
        rollingDoor.GetComponent<Animator>().SetBool("isOpen", false);
    }

}
