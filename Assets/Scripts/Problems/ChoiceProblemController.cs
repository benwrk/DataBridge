using System.Collections.Generic;
using Data.Models.Problems;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

namespace Problems
{
    /// <summary>
    ///     The controller script for the choice problem, designed to be added to UI Canvas of the each Problem
    /// </summary>
    public class ChoiceProblemController : MonoBehaviour
    {
        public Flowchart Flowchart; //Recommend using ProblemHandler by default
        private int _questionOnDisplayIndex;
        private IList<ChoiceQuestion> _randomizedChoiceQuestions;

        public ChoiceQuestion QuestionOnDisplay
        {
            get { return _randomizedChoiceQuestions[_questionOnDisplayIndex]; }
        }

        public void SendQuestionIDToFungus()
        {
            Debug.Log("Message to Fungus: " + QuestionOnDisplay.Id);
            Flowchart.SendFungusMessage(QuestionOnDisplay.Id);
        }
        /// <summary>
        ///     List of UnityEngine.UI.Text, for choices to be displayed in. (Unity Initialized)
        /// </summary>
        public List<Text> ChoiceTexts;

        /// <summary>
        ///     The GameManager. (Unity Initialized)
        /// </summary>
        public GameManager GameManager;

        /// <summary>
        ///     The problem number in 1-indexed format. (Unity Initialized)
        /// </summary>
        public int ProblemNumber;

        /// <summary>
        ///     The UnityEngine.UI.Text component, for the problem text to be displayed in. (Unity Initialized)
        /// </summary>
        public Text ProblemText;

        /// <summary>
        ///     The UnityEngine.UI.Text component, for the question text to be displayed in. (Unity Initialized)
        /// </summary>
        public Text QuestionText;

        private void Start()
        {
            var problem = (ChoiceProblem) GameManager.Problems[ProblemNumber - 1];
            ProblemText.text = problem.Text;

            _randomizedChoiceQuestions = GameUtility.CloneListWithRandomOrder(problem.Questions);

            _questionOnDisplayIndex = 0;
            LoadQuestionAndTagCorrectChoice(_randomizedChoiceQuestions[_questionOnDisplayIndex]);
        }

        /// <summary>
        ///     Load the given question onto the UI, and also tag the correct choice.
        /// </summary>
        /// <param name="question">The question to be loaded.</param>
        private void LoadQuestionAndTagCorrectChoice(ChoiceQuestion question)
        {
            QuestionText.text = question.Text;
            var choices = GameUtility.CloneListWithRandomOrder(question.Choices);

            for (var i = 0; i < ChoiceTexts.Count && i < choices.Count; i++)
            {
                ChoiceTexts[i].text = choices[i].Text;
                ChoiceTexts[i].tag = choices[i].IsCorrect ? Constants.CorrectChoiceTag : Constants.UntaggedTag;
            }
        }

        /// <summary>
        ///     For Fungus to check if the selected choice is correct by verifying the tag on the supplied UI Text component.
        /// </summary>
        /// <param name="selectedChoiceText">The text component of the selected choice</param>
        /// <returns>True if the selected choice is the correct choice, false otherwise</returns>
        public bool IsSelectedChoiceCorrect(Text selectedChoiceText)
        {
            return selectedChoiceText.CompareTag(Constants.CorrectChoiceTag);
        }

        /// <summary>
        ///     Change the question to the specified index.
        /// </summary>
        /// <param name="questionIndex">The index of the question to be changed to.</param>
        private void ChangeQuestion(int questionIndex)
        {
            LoadQuestionAndTagCorrectChoice(_randomizedChoiceQuestions[questionIndex]);
            _questionOnDisplayIndex = questionIndex;
        }

        /// <summary>
        ///     For Fungus to change the displayed question.
        /// </summary>
        /// <returns>The index of the question that is changed to (in 0-indexed).</returns>
        public int ChangeQuestion()
        {
            if (++_questionOnDisplayIndex >= _randomizedChoiceQuestions.Count)
                _questionOnDisplayIndex = 0;
            ChangeQuestion(_questionOnDisplayIndex);
            return _questionOnDisplayIndex;
        }
    }
}