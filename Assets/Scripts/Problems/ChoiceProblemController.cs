using System.Collections.Generic;
using Data.Models.Problems;
using UnityEngine;
using UnityEngine.UI;

namespace Problems
{
    public class ChoiceProblemController : MonoBehaviour
    {
        private IList<ChoiceQuestion> _randomizedChoiceQuestions;
        public List<Text> ChoiceTexts;
        public GameManager GameManager;
        public int ProblemNumber;
        public Text ProblemText;
        public Text QuestionText;

        private void Start()
        {
            var problem = (ChoiceProblem) GameManager.Problems[ProblemNumber - 1];
            ProblemText.text = problem.Text;

            _randomizedChoiceQuestions = GameUtility.CloneListWithRandomOrder(problem.Questions);
            LoadQuestionAndTagCorrectChoice(_randomizedChoiceQuestions[0]);
        }

        /// <summary>
        /// Load the given question onto the UI, and also tag the correct choice.
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
        ///     For Fungus to check if the selected choice is correct.
        /// </summary>
        /// <param name="selectedChoiceText">The text component of the selected choice</param>
        /// <returns>True if the selected choice is the correct choice, false otherwise</returns>
        public bool IsSelectedChoiceCorrect(Text selectedChoiceText)
        {
            return selectedChoiceText.CompareTag(Constants.CorrectChoiceTag);
        }
    }
}