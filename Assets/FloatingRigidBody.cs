using UnityEngine;
using System.Collections;


public class FloatingRigidBody : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        
        if (GameStates.floatingObjectsEnabled)
        {
            gravityChanged();
        }
    }

    void gravityChanged()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * Constants.ZeroGravityFloatStrength);
        transform.Rotate(Constants.ZeroGravityRandomRotationStrength, Constants.ZeroGravityRandomRotationStrength, Constants.ZeroGravityRandomRotationStrength);
    }

}