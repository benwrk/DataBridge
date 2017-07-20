using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Data.Models.Problems;
using Data;

public class QuestionTextGrabber : MonoBehaviour {
    int level;
    
   
    public int questionNumberCQ;
    public Text uiText;
	// Use this for initialization
	void Start ()
    {
        level = 1;
        
        var problems = new List<Problem>();
        problems = Data.ProblemXmlParser.GetProblems(level);
        var firstProblem = problems[0];
       // var ProblemText = firstProblem.Text;

        var Question = (ChoiceQuestion)firstProblem.Questions[questionNumberCQ-1];
        var QuestionText = Question.Text;
        string textForUi = QuestionText;
        
        //var choices = Question.Choices;
        //var firstChoice = choices[0];
        // var firstChoiceText = choices[0].Text;

        // var isFirstChoiceCorrect = choices[0].IsCorrect;
        uiText.text = textForUi;
    }
	

}
