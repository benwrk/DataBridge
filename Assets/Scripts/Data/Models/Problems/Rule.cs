using System;

namespace Data.Models.Problems
{
    public abstract class Rule
    {
        public enum RuleValidationOption
        {
            All,
            Any
        }

        public string Phrase;
    }
}