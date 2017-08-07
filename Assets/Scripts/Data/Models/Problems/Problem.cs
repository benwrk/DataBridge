using System.Collections.Generic;

namespace Data.Models.Problems
{
    public class Problem
    {
        /// <summary>
        /// The problem text.
        /// </summary>
        public string Text;
        /// <summary>
        /// The problem ID.
        /// </summary>
        public string Id;
        /// <summary>
        /// The questions within this problem.
        /// </summary>
        public IList<Question> Questions;
    }
}