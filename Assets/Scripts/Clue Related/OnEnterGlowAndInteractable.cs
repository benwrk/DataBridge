using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterGlowAndInteractable : MonoBehaviour
{
    bool hasCollided;
   
    public GameObject canvas;


    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            hasCollided = true;
            canvas.SetActive(true);
            //labelText = "Hit E to pick up the key!";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasCollided = false;
            canvas.SetActive(false);
        }
    }
}