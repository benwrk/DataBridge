using System;
using Data.Models.Problems;
using System.Collections.Generic;
using System.Linq;

namespace Problems
{
    public static class InputAnswerValidator
    {
        public static bool ValidateAnswer(string answer, IEnumerable<Rule> rules, Rule.RuleValidationOption validationOption)
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

        private static bool ValidateMatches(string a, string b)
        {
            return a.Trim().Equals(b.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        private static bool ValidateContains(string a, string b)
        {
            return a.Trim().ToLower().Contains(b.Trim().ToLower());
        }

        private static bool ValidateWithout(string a, string b)
        {
            return !ValidateContains(a, b);
        }
    }
}