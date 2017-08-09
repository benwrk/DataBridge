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
            ControlledObject.GetComponent<Animator>().SetBool(BoolName, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bot") || other == Player.GetComponent<Collider>())
        {
            ControlledObject.GetComponent<Animator>().SetBool(BoolName, false);
        }
    }
}