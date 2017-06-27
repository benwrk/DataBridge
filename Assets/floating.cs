using UnityEngine;
using System.Collections;

public class floating : MonoBehaviour
{

    public float ZeroGravityFloatStrenght= 8.22f;
    public float ZeroGravityRandomRotationStrenght = 0.2f;
    //bool gravityFlag = true;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * ZeroGravityFloatStrenght);
            transform.Rotate(ZeroGravityRandomRotationStrenght, ZeroGravityRandomRotationStrenght, ZeroGravityRandomRotationStrenght);
        }
        
    }

}