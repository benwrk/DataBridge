using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowController : MonoBehaviour {

    private RaycastHit hittingObject;
    private Color startColor;
    private GameObject currentGlowingObject;

    void Start () {
		
	}

    void Update()
    {
        bool isHittingObject = Physics.Linecast((Camera.main.transform.position),
            (Camera.main.transform.position + Camera.main.transform.forward * 3),
            out hittingObject);

        if (!GameStates.isGrabbing && currentGlowingObject == null && isHittingObject && hittingObject.transform.gameObject.tag == "Pickable")
        {
            currentGlowingObject = hittingObject.collider.gameObject;
            startColor = currentGlowingObject.GetComponent<Renderer>().material.color;
            currentGlowingObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            if ((currentGlowingObject != null) && (GameStates.isGrabbing || hittingObject.collider == null || hittingObject.collider.gameObject != currentGlowingObject))
            {
                currentGlowingObject.GetComponent<Renderer>().material.color = startColor;
                currentGlowingObject = null;
            }
        }
    }
}
