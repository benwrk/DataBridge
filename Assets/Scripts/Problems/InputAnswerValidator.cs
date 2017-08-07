using System;
using Data.Models.Problems;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public static class InputAnswerValidator
    {
        /// <summary>
        /// Validate the provided answer string against the provided rules with given validation option.
        /// </summary>
        /// <param name="answer">Answer string to be validated</param>
        /// <param name="rules">Rules to be validated against</param>
        /// <param name="validationOption">The rule validation option (all or any)</param>
        /// <returns>true if the answer passed the validation, false otherwise.</returns>
        public static bool ValidateAnswer(string answer, IEnumerable<Rule> rules,
            Rule.RuleValidationOption validationOption)
        {
            switch (validationOption)
            {
                case Rule.RuleValidationOption.All:
                    return rules.All(rule => ValidateRule(answer, rule));
                case Rule.RuleValidationOption.Any:
                    return rules.Any(rule => ValidateRule(answer, rule));
                default:
                    throw new ArgumentException("Invalid validation option!");
            }
        }

        /// <summary>
        /// Validate if the given string passed a rule.
        /// </summary>
        /// <param name="s">String to be validated</param>
        /// <param name="rule">Rule to be validated against</param>
        /// <returns>true if the string passed the rule validation, false otherwise.</returns>
        private static bool ValidateRule(string s, Rule rule)
        {
            if (rule.GetType() == typeof(MatchesRule))
                return ValidateMatches(s, rule.Phrase);
            if (rule.GetType() == typeof(ContainsRule))
                return ValidateContains(s, rule.Phrase);
            if (rule.GetType() == typeof(WithoutRule))
                return ValidateWithout(s, rule.Phrase);
            throw new InvalidOperationException("Invalid type of rule");
        }

        /// <summary>
        /// Check if two given string matches each other (case insensitively).
        /// </summary>
        /// <param name="a">First string</param>
        /// <param name="b">Second string</param>
        /// <returns>true if matches, false otherwise.</returns>
        private static bool ValidateMatches(string a, string b)
        {
            return a.Trim().Equals(b.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Check if the given string contains a phrase (case insensitively).
        /// The opposite of ValidateWithout
        /// </summary>
        /// <param name="a">String to be tested</param>
        /// <param name="b">A phrase that the given string should contains</param>
        /// <returns>true if <paramref name="a"/> contains <paramref name="b"/>, false otherwise.</returns>
        private static bool ValidateContains(string a, string b)
        {
            return a.Trim().ToLower().Contains(b.Trim().ToLower());
        }

        /// <summary>
        /// Check if the given string does not contains a phrase (case insenitively).
        /// The opposite of ValidateContains.
        /// </summary>
        /// <param name="a">String to be tested</param>
        /// <param name="b">A phrase that the given string should not contains</param>
        /// <returns>true if <paramref name="a"/> does not contains <paramref name="b"/>, false otherwise.</returns>
        private static bool ValidateWithout(string a, string b)
        {
            return !ValidateContains(a, b);
        }
    }
}