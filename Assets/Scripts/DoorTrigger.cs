using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject ControlledObject;
    public GameObject Player;
    public string BoolName;

    void OnTriggerEnter(Collider other)
    {
        if (other == Player.GetComponent<Collider>())
        {
            ControlledObject.GetComponent<Animator>().SetBool(BoolName, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        ControlledObject.GetComponent<Animator>().SetBool(BoolName, false);
    }
}