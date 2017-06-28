using UnityEngine;
using System.Collections;


public class floating : MonoBehaviour
{

    public float ZeroGravityFloatStrenght= 8.22f;
    public float ZeroGravityRandomRotationStrenght = 0.2f;
    bool floatObject = false;

   
   

    
    void start()
    {
        
   
    }



    void Update()
    {
       
        bool ifMousePressed = Input.GetMouseButtonUp(1);

        if (ifMousePressed)
        {
            floatObject = !floatObject;
            //player.movementSettings.JumpForce = 22;
        }
        if (floatObject)
        {
            gravityChanged();
        }
        






    }



    void gravityChanged()
    {


       // player.movementSettings.JumpForce = 10;

          
           GetComponent<Rigidbody>().AddForce(Vector3.up * ZeroGravityFloatStrenght);

     
            transform.Rotate(ZeroGravityRandomRotationStrenght, ZeroGravityRandomRotationStrenght, ZeroGravityRandomRotationStrenght);
            
        
    }



}