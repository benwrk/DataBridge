using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class OpenTheDoor : MonoBehaviour
{
    public GameObject rollingDoor;
    public GameObject player;
    
    void OnTriggerEnter(Collider gameObject)
    {
        if (gameObject == player.GetComponent<Collider>())
            rollingDoor.GetComponent<Animator>().SetBool("isOpen", true);
    }


    void OnTriggerExit()
    {
        rollingDoor.GetComponent<Animator>().SetBool("isOpen", false);
    }
    
}
