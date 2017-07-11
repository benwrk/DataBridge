using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class OpenTheDoor : MonoBehaviour
{
    public GameObject rollingDoor;
    
    public GameObject MainPlayer;
   /* private DoorState doorState = DoorState.Closed;
    private enum DoorState
    {
        Opened,
        Opening,
        Closed,
        Closing
    }*/

    void OnTriggerEnter(Collider GameObjCollider)
    {

       // if (GameObjCollider == MainPlayer.GetComponent<Collider>() )
      //  {
            rollingDoor.GetComponent<Animator>().Play("Rolling Door Open");
           
       // }
   
    }

    void OnTriggerStay()
    {
        
    }




    void OnTriggerExit()
    {

       
            rollingDoor.GetComponent<Animator>().Play("Rolling Door Close");
           
       

    }




}
