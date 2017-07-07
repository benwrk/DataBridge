using UnityEngine;

public class gameManager : MonoBehaviour
{

    public static bool ifPicked = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameStates.isGrabbing)
        {
            if (Input.GetMouseButtonUp(1))
            {
                GameStates.floatingObjectsEnabled = !GameStates.floatingObjectsEnabled;
            }
        }
    }

}
