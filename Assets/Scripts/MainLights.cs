using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLights : MonoBehaviour
{
    

    public void IncreaseRange()
    {

        GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");

        foreach (GameObject light in lights)
        {
            light.GetComponent<Animator>().Play("Lights on", 0, 0);
        }
    }

}
