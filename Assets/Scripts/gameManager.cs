using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!GameStates.IsGrabbing && Input.GetMouseButtonUp(1))
        {
            GameStates.FloatingObjectsEnabled = !GameStates.FloatingObjectsEnabled;
        }
    }
}