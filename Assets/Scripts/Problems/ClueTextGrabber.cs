using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Models.Clues;
using Data;
using UnityEngine.UI;

public class ClueTextGrabber : MonoBehaviour {
    int level;
    public int questionNumberCQ;
    public Text uiText;





    // Use this for initialization
    void Start () {
        level = 1;
        var clue = new List<Clue>();
        clue = Data.ClueXmlParser.GetClues(level);

        var clueText = clue[questionNumberCQ-1].Text;
        string textForUi = clueText;
        uiText.text = textForUi;




    }
	

}
