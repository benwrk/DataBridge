using System.Collections.Generic;

namespace Data.Models.Problems
{
    public class InputProblem : Problem
    {
        /// <summary>
        ///     The list of input questions within this problem.
        ///     <seealso cref="Problem.Questions" />
        /// </summary>
        public new IList<InputQuestion> Questions;
    }
}