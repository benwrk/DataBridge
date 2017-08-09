using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public string BoolName;
    public GameObject ControlledObject;
    public GameObject Player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bot") || other == Player.GetComponent<Collider>())
        {
            Debug.Log(other.name + " is trying to open " + ControlledObject.name);
            ControlledObject.GetComponent<Animator>().SetBool(BoolName, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bot") || other == Player.GetComponent<Collider>())
        {
            Debug.Log(other.name + " is trying to close " + ControlledObject.name);
            ControlledObject.GetComponent<Animator>().SetBool(BoolName, false);
        }
    }
}