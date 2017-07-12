using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DoorTrigger : MonoBehaviour
{
    public GameObject controlledObject;
    public GameObject player;
    public string boolName;
    
    void OnTriggerEnter(Collider gameObject)
    {
        if (gameObject == player.GetComponent<Collider>())
        {
            controlledObject.GetComponent<Animator>().SetBool(boolName, true);
        }
    }


    void OnTriggerExit()
    {
        controlledObject.GetComponent<Animator>().SetBool(boolName, false);
    }
    
}
