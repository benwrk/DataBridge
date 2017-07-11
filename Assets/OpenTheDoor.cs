using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class OpenTheDoor : MonoBehaviour
{
    public GameObject rollingDoor;
    
    public GameObject MainPlayer;
    bool opening = false;
   
   
    void OnTriggerEnter(Collider GameObjCollider)
    {

        if (GameObjCollider == MainPlayer.GetComponent<Collider>() )
        {
            if (opening == false)
          {
                OpenDoor();
           }
        }
   
    }

    void OnTriggerStay()
    {
        



    }




    void OnTriggerExit()
    {

        opening = true;
            //CloseDoor();
    }



    void FixedUpdate()
    {
        if(opening == false)
        CloseDoor();



    }

   


    void OpenDoor()
    {
       
        rollingDoor.GetComponent<Animation>().Play("Rolling Door Open");
        //SetFlag();
    }

    void CloseDoor()
    {
   
        rollingDoor.GetComponent<Animation>().Play("Rolling Door Close");
        Invoke("SetFlag", 0);
   
    }


    void SetFlag()
    {
        opening = !opening;
    }


    




}
