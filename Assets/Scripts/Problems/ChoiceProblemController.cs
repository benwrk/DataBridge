using System.Collections.Generic;
using Data.Models.Problems;
using UnityEngine;
using UnityEngine.UI;

namespace Problems
{
    public class ChoiceProblemController : MonoBehaviour
    {
        private IList<ChoiceQuestion> _randomizedChoiceQuestions;

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
            LoadQuestionAndTagCorrectChoice(_randomizedChoiceQuestions[0]);
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
                if (choices[i].IsCorrect)
                    ChoiceTexts[i].tag = Constants.CorrectChoiceTag;
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
    }
}