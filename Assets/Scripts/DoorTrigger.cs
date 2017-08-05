using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public string BoolName;
    public GameObject ControlledObject;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other == Player.GetComponent<Collider>() || GameObject.FindGameObjectWithTag("bot"))
            ControlledObject.GetComponent<Animator>().SetBool(BoolName, true);
    }

    private void OnTriggerExit(Collider other)
    {
        ControlledObject.GetComponent<Animator>().SetBool(BoolName, false);
    }
}