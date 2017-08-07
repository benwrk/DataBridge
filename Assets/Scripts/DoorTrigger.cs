using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public string BoolName;
    public GameObject ControlledObject;
    public GameObject Player;
    public GameObject BotGameObject;
    private static bool set = false;
    private void OnTriggerEnter(Collider other)
    {
        if (set == true)
           return;
        if (other.tag == "Bot")
        {
          
            Animator a = ControlledObject.GetComponent<Animator>();
          
            Debug.Log("success");
            a.SetBool(BoolName, true);
            set = true;
        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (set == true)
            return;
        if (other.tag == "Bot")
        {
            Debug.Log("close door");
            ControlledObject.GetComponent<Animator>().SetBool(BoolName, false);
        }

    }

    void Update()
    {
        set = false;
    }
}