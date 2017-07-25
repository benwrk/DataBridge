using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InputHandler : MonoBehaviour {

    string currentString;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void EndEditListener(string s)
    {
        currentString = s;
    }

    public void PassString(string neededString)
    {
        Debug.Log(currentString);
        currentString = null;
        EventSystem.current.SetSelectedGameObject(null);
    }




}
