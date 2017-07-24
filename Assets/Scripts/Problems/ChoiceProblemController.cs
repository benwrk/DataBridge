using Data.Models.Problems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ChoiceProblemController : MonoBehaviour
{
    public GameManager GameManager;
    public GameObject Controller;
    public RigidbodyFirstPersonController RbController;

    public Text QuestionText;
    public Text ProblemText;
    public Text Choice1;
    public Text Choice2;
    public Text Choice3;
    public Text Choice4;
    
    public int ProblemNumber;
    private List<ChoiceQuestion> _choiceQuestions;

    private static List<T> GetRandomlyOrderedList<T>(List<T> originalList)
    {
        var originalListClone = new List<T>(originalList);
        var randomizedList = new List<T>();
        
        var random = new System.Random();
        while (originalListClone.Count > 0)
        {
            var randomNumber = random.Next(0, originalListClone.Count - 1);
            randomizedList.Add(originalListClone[randomNumber]);
            originalListClone.RemoveAt(randomNumber);
        }

        return randomizedList;
    }

    private void Start()
    {
        var problem = (ChoiceProblem) GameManager.Problems[ProblemNumber - 1];
        ProblemText.text = problem.Text;

        _choiceQuestions = GetRandomlyOrderedList(problem.Questions);
        LoadQuestion(_choiceQuestions, 0);
    }

    private void LoadQuestion(IList<ChoiceQuestion> questions, int questionNumber)
    {
        var question = questions[questionNumber];
        QuestionText.text = question.Text;

        var choices = GetRandomlyOrderedList(question.Choices);
        Choice1.text = choices[0].Text;
        Choice2.text = choices[1].Text;
        Choice3.text = choices[2].Text;
        Choice4.text = choices[3].Text;
    }

    //// Use this for initialization
    //private void Start()
    //{
    //    Cursor.visible = false;

    //}

    //private void ToggleFreezeOfPlayer()
    //{
    //    Controller.GetComponent<PlayerController>().ToggleFreeze();
    //    RbController.lookRotationEnabled = !RbController.lookRotationEnabled;
    //    if (Cursor.lockState == CursorLockMode.Locked)
    //    {
    //        Cursor.lockState = CursorLockMode.Confined;
    //        Debug.Log(Cursor.lockState);
    //    }
    //    else if (Cursor.lockState == CursorLockMode.Confined)
    //    {
    //        Cursor.lockState = CursorLockMode.Locked;
    //        Debug.Log(Cursor.lockState);
    //    }

    //    if (Cursor.visible)
    //    {
    //        Cursor.visible = false;
    //    }
    //    else if (!Cursor.visible)
    //    {
    //        Cursor.visible = true;
    //    }
    //}
}
