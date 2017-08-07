using System;

namespace Data.Models.Problems
{
    public abstract class Rule
    {
        /// <summary>
        /// The options of how the rules will be validated.
        /// </summary>
        public enum RuleValidationOption
        {
            /// <summary>
            /// For the candidate to pass the validation it will need to satisfies all rules given.
            /// </summary>
            All,
            /// <summary>
            /// The candidate will pass the validation if it satisfies any rule.
            /// </summary>
            Any
        }

        /// <summary>
        /// The string for the rule to be verfied against.
        /// </summary>
        public string Phrase;
    }
}