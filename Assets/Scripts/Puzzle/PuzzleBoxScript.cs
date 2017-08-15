using UnityEngine;

public class PuzzleBoxScript : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<FloatingRigidBody>().enabled = false;
    }

    private void FixedUpdate()
    {
        if (GameStates.PuzzleTrigger)
        {
            GetComponent<FloatingRigidBody>().enabled = true;
            if (!GameStates.FloatingObjectsEnabled)
                MassIncrease();
            else
            {
                GetComponent<Rigidbody>().mass = 1;
            }
        }
    }

    private void MassIncrease()
    {
        GetComponent<Rigidbody>().mass = 1000;
    }
}