using System.Collections.Generic;

namespace Data.Models.Problems
{
    public class InputQuestion : Question
    {
        public string Placeholder;
        public IList<Rule> Rules;
        public Rule.RuleValidationOption RuleValidation;
    }
}