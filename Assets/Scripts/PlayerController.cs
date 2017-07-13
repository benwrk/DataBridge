using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{

    public RigidbodyFirstPersonController controller;
    public bool isFrozen;

    private Vector3 initialLocation;
    private Vector3 initialRotation;
    private GameObject grabbedObject;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (grabbedObject == null) //if havent grabbed any object, grab one
            {
                TryGrabObject(GetMouseHoverObject(3));
            }
            else
            {
                DropObject(); //if we alredy have something on our hand then drop it
            }
        }


        if (grabbedObject != null)//if we have grabbed an object , change its position to in front of us
        {
            FocusOnObjectAndLockCamera();
        }

        if (isFrozen)
        {
            DisableMovements();
        }
        else
        {
            EnableMovements();
        }
    }

    //function that gives us the object that we are looking at
    private GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = Camera.main.transform.position; // check it gameObject.transform.position + new Vector3(0, 1, 0) ;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        if (Physics.Linecast(position, target, out raycastHit) && raycastHit.transform.gameObject.tag == "Pickable")
        {

            GameStates.isGrabbing = true;//by making it true, we cant make the objects float , check Game Manager for further info
            return raycastHit.collider.gameObject;
        }
        Debug.DrawLine(position, target, Color.cyan, 10.0f);
        // if theres no collision then the code will get down further
        return null;

    }
    
    private void TryGrabObject(GameObject grabObject)
    {
        // check if actually a thing that we can grab
        if (grabObject == null || !IsGrabbable(grabObject)) // if it's nothing then u cant grab it and return
            return;

        
        grabbedObject = grabObject;
        // grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude; // used to make the object float at a certain distance from the camera depending on the size of the object 
        grabObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; // the object while observing should not rotate (freeze the rotation)


        initialLocation = grabbedObject.transform.position;
        initialRotation = new Vector3(grabbedObject.transform.eulerAngles.x, grabbedObject.transform.eulerAngles.y, grabbedObject.transform.eulerAngles.z);


        controller.lookRotationEnabled = false;
        Camera.main.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);

        isFrozen = true;
        
        //freeze the movements of the player while obsering the object
        

        //by making it true, we cant make the objects float , check Game Manager for further info
    }

    private bool IsGrabbable(GameObject candidate) // we can grab the object if it has a rigid body
    {
        return candidate.GetComponent<Rigidbody>() != null;// if we find the rigid body, return true
    }

    private void DropObject()
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

            isFrozen = false;
            //un-freeze the movements of the player while obsering the object
            

            //by making it false, we can make the objects float , check Game Manager for further info
            GameStates.isGrabbing = false;
        }
        grabbedObject.transform.position = initialLocation;
        grabbedObject.transform.eulerAngles = new Vector3(initialRotation.x, initialRotation.y, initialRotation.z);
        controller.movementSettings.JumpForce = 40;


        grabbedObject = null;
        controller.CameraFoVReset();
    }

    private void FocusOnObjectAndLockCamera()
    {
        grabbedObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 1)); ;
        controller.CameraFoVChange(90, 30, 2);
        grabbedObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X")) * Time.deltaTime * Constants.ZeroGravityRotationSpeed);
    }

    public void DisableMovements()
    {
        controller.movementSettings.ForwardSpeed = 0;
        controller.movementSettings.BackwardSpeed = 0;
        controller.movementSettings.StrafeSpeed = 0;
        controller.movementSettings.JumpForce = 0;
    }

    public void EnableMovements()
    {
        controller.movementSettings.ForwardSpeed = Constants.DefaultForwardSpeed;
        controller.movementSettings.BackwardSpeed = Constants.DefaultBackwardSpeed;
        controller.movementSettings.StrafeSpeed = Constants.DefaultStrafeSpeed;
        controller.movementSettings.JumpForce = Constants.DefaultJumpForce;
    }
}
