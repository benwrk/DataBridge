using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalGravity : MonoBehaviour
{

    public Vector3 fullGravity;
    public Vector3 microGravity;
    

    // Use this for initialization
    void Start()
    {
        fullGravity = new Vector3(0, -1.5F, 0);
        microGravity = new Vector3(0, -0.2f, 0);

        Physics.gravity = fullGravity;


       


    }

    // Update is called once per frame
    void Update()
    {





        if (Input.GetKeyUp(KeyCode.G))
        {
            if (Physics.gravity.Equals(fullGravity))
            {
                Physics.gravity = microGravity;
                randomforce.speed = 0.7F;
                
            }
            else
            {
                Physics.gravity = fullGravity;
                randomforce.speed =0;
            }
        }


       



    }
}
