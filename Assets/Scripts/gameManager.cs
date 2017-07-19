using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject controller;
   
    // Update is called once per frame
    private void Update()
    {
        if (!GameStates.IsGrabbing && Input.GetMouseButtonUp(1))
            GameStates.FloatingObjectsEnabled = !GameStates.FloatingObjectsEnabled;

        

      


        }
}