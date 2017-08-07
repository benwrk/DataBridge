using System.Collections.Generic;

namespace Data.Models.Problems
{
    public class ChoiceQuestion : Question
    {
        /// <summary>
        /// The list of choices within this question.
        /// </summary>
        public IList<Choice> Choices;
    }
}