using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterGlowAndInteractable : MonoBehaviour
{
    
    public GameObject ClueLight;
    public GameObject canvas;
    private bool Entered;
    


    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            ClueLight.SetActive(true);
            canvas.SetActive(true);
            Entered = true;
            //labelText = "Hit E to pick up the key!";
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ClueLight.SetActive(false);
            canvas.SetActive(false);
            Entered = false;
        }
    }

    void Update()
    {
        if (Entered)
        {
            if (Input.GetButtonUp("u"))
            {
               /* PlayerController.GrabObject(PlayerController.GetObjectAtCameraCenter(Constants.GrabbingCameraCenterRange));
                else
                    DropObject();

                if (_grabbedObject != null)
                    CenterLockGrabbedObject();

                if (IsFrozen)
                    DisableMovements();
                else
                    EnableMovements();*/
            }
        }

    }



}