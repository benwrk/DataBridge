using System.Collections.Generic;

namespace Data.Models.Problems
{
    public class InputQuestion : Question
    {
        
        public string Placeholder;
        public List<Rule> Rules;
        public Rule.RuleValidationOption RuleValidation;
    }
}