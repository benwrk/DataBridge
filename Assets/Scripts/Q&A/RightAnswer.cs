using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightAnswer : MonoBehaviour {

    public Button TheButton;
    //public Color newColor = Color.red;

    void Start()
    {
        TheButton = GetComponent<Button>();
        TheButton.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        TheButton.interactable = false;



    }
}