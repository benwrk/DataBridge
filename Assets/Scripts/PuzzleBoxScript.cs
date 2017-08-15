using UnityEngine;

public class PuzzleBoxScript : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (!GameStates.FloatingObjectsEnabled)
            MassIncrease();
        else
        {
            GetComponent<Rigidbody>().mass = 1;
        }
    }

    private void MassIncrease()
    {
        GetComponent<Rigidbody>().mass = 10;
    }
}
