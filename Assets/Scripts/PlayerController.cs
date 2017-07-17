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
            if (_grabbedObject == null)
            {
                GrabObject(GetObjectAtCameraCenter(Constants.GrabbingCameraCenterRange));
            }
            else
            {
                DropObject();
            }
        }

        if (_grabbedObject != null)
        {
            CenterLockGrabbedObject();
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

    /// <summary>
    /// Get the current objectToGrab under the center of the camera.
    /// </summary>
    /// <param name="range">Maximum range to be deemed under</param>
    /// <returns>GameObject under the center of the camera (or null if nothing is found)</returns>
    private static GameObject GetObjectAtCameraCenter(float range)
    {
        var position = Camera.main.transform.position;
        var target = position + Camera.main.transform.forward * range;
        RaycastHit raycastHit;

        if (Physics.Linecast(position, target, out raycastHit) && raycastHit.transform.gameObject.CompareTag(Constants.GrabbableTag))
        {
            GameStates.IsGrabbing = true;
            return raycastHit.collider.gameObject;
        }
        Debug.DrawLine(position, target, Color.cyan, 10.0f);
        return null;
    }

    private void GrabObject(GameObject objectToGrab)
    {
        if (!HasRigidbody(objectToGrab))
        {
            Debug.Log("Nothing to Grab!");
            return;
        }

        _grabbedObject = objectToGrab;
        // grabbedObjectSize = objectToGrab.GetComponent<Renderer>().bounds.size.magnitude; // used to make the objectToGrab float at a certain distance from the camera depending on the size of the objectToGrab 

        // The object should not rotate around when grabbed.
        objectToGrab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        _initialLocation = _grabbedObject.transform.position;
        _initialRotation = new Vector3(_grabbedObject.transform.eulerAngles.x, _grabbedObject.transform.eulerAngles.y,
            _grabbedObject.transform.eulerAngles.z);

        Controller.lookRotationEnabled = false;
        Camera.main.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y,
            Camera.main.transform.eulerAngles.z);

        IsFrozen = true;
    }

    /// <summary>
    /// Test if the GameObject has a Rigidbody component
    /// </summary>
    /// <param name="objectToTest">The GameObject to be tested</param>
    /// <returns>True if the GameObject is not null has an underlying Rigidbody component, false otherwise</returns>
    private static bool HasRigidbody(GameObject objectToTest)
    {
        return objectToTest != null && objectToTest.GetComponent<Rigidbody>() != null;
    }

    private void DropObject()
    {
        if (_grabbedObject == null)
        {
            return;
        }

        _grabbedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

        // Resume rotation.
        _grabbedObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        Controller.lookRotationEnabled = true;
        IsFrozen = false;

        GameStates.IsGrabbing = false;
        
        _grabbedObject.transform.position = _initialLocation;
        _grabbedObject.transform.eulerAngles = new Vector3(_initialRotation.x, _initialRotation.y, _initialRotation.z);

        _grabbedObject = null;
        Controller.CameraFoVReset();
    }

    private void CenterLockGrabbedObject()
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
