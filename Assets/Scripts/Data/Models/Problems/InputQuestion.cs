using System.Collections.Generic;

namespace Data.Models.Problems
{
    public class InputQuestion : Question
    {
        /// <summary>
        /// The placeholder (input hint) for this question.
        /// </summary>
        public string Placeholder;
        /// <summary>
        /// The rules for verifying the answer of this question.
        /// </summary>
        public IList<Rule> Rules;
        /// <summary>
        /// The validation option for rules (all or any).
        /// </summary>
        public Rule.RuleValidationOption RuleValidation;
    }
}