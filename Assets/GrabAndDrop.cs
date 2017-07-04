using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class GrabAndDrop : MonoBehaviour {



    private float timeLerp = 50f;
    
     
    private GameObject grabbedObject;
   // private float grabbedObjectSize;
    private RigidbodyFirstPersonController controller; // being used to freeze the player movements while observing
    //private static readonly Vector3 adjustTheHeightOfTheObject = new Vector3(-0.25f, 0.5f, 0); // the point at whihc the object is being held while observing relative to the camera

    void Start()
    {
        controller = GetComponent<RigidbodyFirstPersonController>();
       
    }

    //function that gives us the object that we are looking at
    GameObject GetMouseHoverObject (float range)
    {
        Vector3 position =  Camera.main.transform.position; // check it gameObject.transform.position + new Vector3(0, 1, 0) ;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        if (Physics.Linecast(position, target, out raycastHit) && raycastHit.transform.gameObject.tag == "Pickable")
        {
            return raycastHit.collider.gameObject;
        }
        Debug.DrawLine(position, target, Color.cyan, 10.0f);
        // if theres no collision then the code will get down further
        return null;

    }

   




    void tryGrabObject(GameObject grabObject)
    {
        // check if actually a thing that we can grab
        if (grabObject == null || !CanGrab(grabObject)) // if it's nothing then u cant grab it and return
            return;

        grabbedObject = grabObject;
       // grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude; // used to make the object float at a certain distance from the camera depending on the size of the object 
        grabObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; // the object while observing should not rotate (freeze the rotation)
        controller.lookRotationEnabled = false;
        Camera.main.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);
        //freeze the movements of the player while obsering the object
        controller.movementSettings.ForwardSpeed = 0;
        controller.movementSettings.BackwardSpeed = 0;
        controller.movementSettings.StrafeSpeed = 0;
        controller.movementSettings.JumpForce = 0;
        
        //by making it true, we cant make the objects float , check Game Manager for further info
        GameStates.isGrabbing = true;
        
    }



    bool CanGrab(GameObject candidate) // we an grab the object if it has a rigid body
    {
        return candidate.GetComponent<Rigidbody>() != null;// if we find the rigid body, return true
    }



    void DropObject()
    {

        if (grabbedObject == null) // if nothing is grabbed then 
        {
            return;
        }

        if (grabbedObject.GetComponent<Rigidbody>() != null) // if the grabbed object has a rigid body, not null 
        {
            grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero; // while dropping the object , they should be released with zero velocity (basically you cant throw an object in some direction)
            grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // un-freeze the rotation when the objct is dropped

            controller.lookRotationEnabled = true;
            //un-freeze the movements of the player while obsering the object
            controller.movementSettings.ForwardSpeed = Constants.DefaultForwardSpeed;
            controller.movementSettings.BackwardSpeed = Constants.DefaultBackwardSpeed;
            controller.movementSettings.StrafeSpeed = Constants.DefaultStrafeSpeed;
            controller.movementSettings.JumpForce = Constants.DefaultJumpForce;

            //by making it false, we can make the objects float , check Game Manager for further info
            GameStates.isGrabbing = false;
        }

        grabbedObject = null;


    }


	// Update is called once per frame
	void Update () {
        //Debug.Log(GetMouseHoverObject(5));

        if (Input.GetMouseButtonDown(0))
        {
            if (grabbedObject == null) //if havent grabbed any object, grab one
            {
                tryGrabObject(GetMouseHoverObject(3));
            }
            else
            {
                DropObject(); //if we alredy have something on our hand then drop it
            }
        }

        if (grabbedObject != null)//if we have grabbed an object , change its position to in front of us
        {
            //Vector3 newPosition = gameObject.transform.position + Camera.main.transform.forward * (grabbedObjectSize) + (Vector3.up - adjustTheHeightOfTheObject );
          
 
            grabbedObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 1)); ;
        }
	}
}
  