using System.Collections.Generic;

namespace Data.Models.Problems
{
    public class ChoiceProblem : Problem
    {
        /// <summary>
        ///     The list of choice questions within this problem.
        ///     <seealso cref="Problem.Questions" />
        /// </summary>
        public new IList<ChoiceQuestion> Questions;
    }
}