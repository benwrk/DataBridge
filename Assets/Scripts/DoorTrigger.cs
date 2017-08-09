using UnityEngine;

/// <summary>
///     Controller for door triggers.
/// </summary>
public class DoorTrigger : MonoBehaviour
{
    /// <summary>
    ///     The name of the boolean parameter that lies within the ControlledObject's Animator. (Unity Initialized)
    /// </summary>
    public string BoolName;

    /// <summary>
    ///     The object reference of the door that is being controlled by this controller. (Unity Initialized)
    /// </summary>
    public GameObject ControlledObject;

    /// <summary>
    ///     The player object, used to allow players to open doors. (Unity Initialized)
    /// </summary>
    public GameObject Player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bot") || other == Player.GetComponent<Collider>())
        {
            Debug.Log(other.name + " is trying to open " + ControlledObject.name);
            ControlledObject.GetComponent<Animator>().SetBool(BoolName, true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        OnTriggerEnter(other);
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