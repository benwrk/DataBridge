using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerController : MonoBehaviour
{
    public RigidbodyFirstPersonController Controller;
    public bool IsFrozen;

    private Vector3 _initialLocation;
    private Vector3 _initialRotation;
    private GameObject _grabbedObject;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_grabbedObject == null) //if havent grabbed any object, grab one
            {
                TryGrabObject(GetMouseHoverObject(3));
            }
            else
            {
                DropObject(); //if we alredy have something on our hand then drop it
            }
        }


        if (_grabbedObject != null)//if we have grabbed an object , change its position to in front of us
        {
            FocusOnObjectAndLockCamera();
        }

        if (IsFrozen)
        {
            DisableMovements();
        }
        else
        {
            EnableMovements();
        }
    }

    //function that gives us the object that we are looking at
    private static GameObject GetMouseHoverObject(float range)
    {
        var position = Camera.main.transform.position; // check it gameObject.transform.position + new Vector3(0, 1, 0) ;
        var target = position + Camera.main.transform.forward * range;
        RaycastHit raycastHit;
        
        if (Physics.Linecast(position, target, out raycastHit) && raycastHit.transform.gameObject.CompareTag("Pickable"))
        {
            GameStates.IsGrabbing = true;//by making it true, we cant make the objects float , check Game Manager for further info
            return raycastHit.collider.gameObject;
        }
        Debug.DrawLine(position, target, Color.cyan, 10.0f);
        // if theres no collision then the code will get down further
        return null;
    }
    
    private void TryGrabObject(GameObject grabObject)
    {
        // check if actually a thing that we can grab
        if (grabObject == null || !HasRigidbody(grabObject))
        {
            // if it's nothing then u cant grab it and return
            return;
        }

        _grabbedObject = grabObject;
        // grabbedObjectSize = grabObject.GetComponent<Renderer>().bounds.size.magnitude; // used to make the object float at a certain distance from the camera depending on the size of the object 
        grabObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; // the object while observing should not rotate (freeze the rotation)


        _initialLocation = _grabbedObject.transform.position;
        _initialRotation = new Vector3(_grabbedObject.transform.eulerAngles.x, _grabbedObject.transform.eulerAngles.y, _grabbedObject.transform.eulerAngles.z);


        Controller.lookRotationEnabled = false;
        Camera.main.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y, Camera.main.transform.eulerAngles.z);

        IsFrozen = true;
        
        //freeze the movements of the player while obsering the object
        

        //by making it true, we cant make the objects float , check Game Manager for further info
    }

    private static bool HasRigidbody(GameObject candidate) // we can grab the object if it has a rigid body
    {
        return candidate.GetComponent<Rigidbody>() != null;// if we find the rigid body, return true
    }

    private void DropObject()
    {

        if (_grabbedObject == null) // if nothing is grabbed then 
        {
            return;
        }

        if (_grabbedObject.GetComponent<Rigidbody>() != null) // if the grabbed object has a rigid body, not null 
        {

            _grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero; // while dropping the object , they should be released with zero velocity (basically you cant throw an object in some direction)
            _grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; // un-freeze the rotation when the objct is dropped

            Controller.lookRotationEnabled = true;

            IsFrozen = false;
            //un-freeze the movements of the player while obsering the object
            

            //by making it false, we can make the objects float , check Game Manager for further info
            GameStates.IsGrabbing = false;
        }
        _grabbedObject.transform.position = _initialLocation;
        _grabbedObject.transform.eulerAngles = new Vector3(_initialRotation.x, _initialRotation.y, _initialRotation.z);
        Controller.movementSettings.JumpForce = 40;


        _grabbedObject = null;
        Controller.CameraFoVReset();
    }

    private void FocusOnObjectAndLockCamera()
    {
        _grabbedObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 1));
        Controller.CameraFoVChange(90, 30, 2);
        _grabbedObject.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse Y"), -Input.GetAxis("Mouse X")) * Time.deltaTime * Constants.ZeroGravityRotationSpeed);
    }

    private void DisableMovements()
    {
        Controller.movementSettings.ForwardSpeed = 0;
        Controller.movementSettings.BackwardSpeed = 0;
        Controller.movementSettings.StrafeSpeed = 0;
        Controller.movementSettings.JumpForce = 0;
    }

    private void EnableMovements()
    {
        Controller.movementSettings.ForwardSpeed = Constants.DefaultForwardSpeed;
        Controller.movementSettings.BackwardSpeed = Constants.DefaultBackwardSpeed;
        Controller.movementSettings.StrafeSpeed = Constants.DefaultStrafeSpeed;
        Controller.movementSettings.JumpForce = Constants.DefaultJumpForce;
    }

    public void ToggleFreeze()
    {
        IsFrozen = !IsFrozen;
    }
}
