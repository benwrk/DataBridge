using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Clue_Related
{
    public class OnEnterGlowAndInteractable : MonoBehaviour
    {
        public GameObject ClueLight;
        public GameObject Canvas;
        private bool _entered;

        public GameObject ClueObjectToView;
        private Vector3 _initialLocation;
        private Vector3 _initialRotation;
        public RigidbodyFirstPersonController Controller;
        public GameObject MainCam;
        private bool _pickedClue;


        private void Update()
        {
            if (_entered)
            {
                if (Input.GetKeyUp(KeyCode.U))
                {
                    if (_pickedClue == false)
                        GrabObject();
                    else
                        DropObject();
                }
                if (_pickedClue)
                        CenterLockGrabbedObject();

                    if (GameStates.IsFrozen)
                        DisableMovements();
                    else
                        EnableMovements();
                
            }
            
            
        }

        private void GrabObject()
        {
            ClueObjectToView.SetActive(true);

            _initialLocation = ClueObjectToView.transform.position;
            _initialRotation = new Vector3(ClueObjectToView.transform.eulerAngles.x,
                ClueObjectToView.transform.eulerAngles.y,
                ClueObjectToView.transform.eulerAngles.z);

            Controller.lookRotationEnabled = false;
            Camera.main.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y,
                Camera.main.transform.eulerAngles.z);
            ClueObjectToView.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 1f));
            ClueObjectToView.GetComponent<Transform>().LookAt(MainCam.GetComponent<Transform>());
            GameStates.IsFrozen = true;
            _pickedClue = true;
        }

        private void DropObject()
        {
            if (_pickedClue == false)
                return;
            
            // Resume rotation.
            ClueObjectToView.SetActive(false);

            Controller.lookRotationEnabled = true;
            GameStates.IsFrozen = false;

            //GameStates.IsGrabbing = false;

            ClueObjectToView.transform.position = _initialLocation;
            ClueObjectToView.transform.eulerAngles =
                new Vector3(_initialRotation.x, _initialRotation.y, _initialRotation.z);

            _pickedClue = false;
            Controller.CameraFoVReset();
        }

        private void CenterLockGrabbedObject()
        {

            Controller.CameraFoVChange(90, 30, 2);
            
            ClueObjectToView.transform.Rotate(new Vector3(0, -Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) *Time.deltaTime * Constants.ZeroGravityRotationSpeed);
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


        private void OnTriggerEnter(Collider c)
        {
            if (c.gameObject.CompareTag("Player"))
            {
                ClueLight.SetActive(true);
                Canvas.SetActive(true);
                _entered = true;
                //labelText = "Hit E to pick up the key!";
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                ClueLight.SetActive(false);
                Canvas.SetActive(false);
                _entered = false;
            }
        }
    }
}