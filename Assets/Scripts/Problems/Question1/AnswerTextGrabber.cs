using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Models.Problems;
using Data;
using UnityEngine.UI;

public class AnswerTextGrabber : MonoBehaviour {
    int level;

    public int questionNumberCQ;
    public int answerNumberCQ;
    public Text uiText;
    // Use this for initialization
    void Start () {
        level = 1;
        var problems = new List<Problem>();
        problems = Data.ProblemXmlParser.GetProblems(level);
        var firstProblem = problems[0];
        var Question = (ChoiceQuestion)firstProblem.Questions[questionNumberCQ - 1];

        var choices = Question.Choices;
        var Choice = choices[answerNumberCQ-1];
        var ChoiceText = choices[answerNumberCQ -1].Text;
        string textForUi = ChoiceText;
        uiText.text = textForUi;
    }


}
