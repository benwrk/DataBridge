using System.Collections.Generic;
using Data.Models.Problems;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

namespace Problems
{
    public class ChoiceProblemController : MonoBehaviour
    {
        public GameManager GameManager;
        public GameObject Controller;
        public RigidbodyFirstPersonController RbController;

        public Text QuestionText;
        public Text ProblemText;
    
        public int ProblemNumber;
        public List<Text> ChoiceTexts;

        private IList<ChoiceQuestion> _randomizedChoiceQuestions;
        
        private void Start()
        {
            var problem = (ChoiceProblem) GameManager.Problems[ProblemNumber - 1];
            ProblemText.text = problem.Text;

            _randomizedChoiceQuestions = GameUtility.CloneListWithRandomOrder(problem.Questions);
            LoadQuestion(_randomizedChoiceQuestions, 0);
        }

        private void LoadQuestion(IList<ChoiceQuestion> questions, int questionNumber)
        {
            var question = questions[questionNumber];
            QuestionText.text = question.Text;

            var choices = GameUtility.CloneListWithRandomOrder(question.Choices);

            for (var i = 0; i < ChoiceTexts.Count && i < choices.Count; i++)
            {
                ChoiceTexts[i].text = choices[i].Text;
                if (choices[i].IsCorrect)
                {
                    ChoiceTexts[i].tag = Constants.CorrectChoiceTag;
                }
            }
        }

        /// <summary>
        /// For Fungus to check if the selected choice is correct.
        /// </summary>
        /// <param name="selectedChoiceText">The text component of the selected choice</param>
        /// <returns>True if the selected choice is the correct choice, false otherwise</returns>
        public bool IsSelectedChoiceCorrect(Text selectedChoiceText)
        {
            return selectedChoiceText.CompareTag(Constants.CorrectChoiceTag);
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
}
