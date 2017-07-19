using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using Data.Models.Problems;

namespace Data
{
    public class ProblemXmlParser
    {
        public static List<Problem> GetProblems(int level)
        {
            var document = new XmlDocument();
            document.Load(Constants.XmlParser.Problems.ConfigFilePath);

            var levels = document.GetElementsByTagName(Constants.XmlParser.Problems.LevelTagName);
            var selectedLevel = levels[level - 1];

            var problems = new List<Problem>();

            foreach (XmlElement problemElement in selectedLevel.ChildNodes)
            {
                var questions = new List<Question>();
                foreach (XmlElement questionElement in problemElement.ChildNodes)
                {
                    switch (questionElement.Name)
                    {
                        case "ChoiceQuestion":
                            var choiceQuestion = new ChoiceQuestion()
                            {
                                Text = questionElement.GetAttribute("text"),
                                Choices = new List<Choice>()
                            };
                            foreach (XmlElement choiceElement in questionElement.ChildNodes)
                            {
                                choiceQuestion.Choices.Add(new Choice()
                                {
                                    Text = choiceElement.GetAttribute("text"),
                                    IsCorrect = choiceElement.HasAttribute("correct") && choiceElement.GetAttribute("correct").Equals("true")
                                });
                            }
                            questions.Add(choiceQuestion);
                            break;

                        case "InputQuestion":
                            var inputQuestion = new InputQuestion()
                            {
                                Text = questionElement.GetAttribute("text"),
                                Placeholder = questionElement.GetAttribute("placeholder"),
                                Rules = new List<Rule>()
                            };
                            foreach (XmlElement ruleElement in questionElement.ChildNodes)
                            {
                                var phrase = ruleElement.GetAttribute("phrase");
                                switch (ruleElement.Name)
                                {
                                    case "MatchesRule":
                                        inputQuestion.Rules.Add(new MatchesRule()
                                        {
                                            Phrase = phrase
                                        });
                                        break;
                                    case "ContainsRule":
                                        inputQuestion.Rules.Add(new ContainsRule()
                                        {
                                            Phrase = phrase
                                        });
                                        break;
                                    case "WithoutRule":
                                        inputQuestion.Rules.Add(new WithoutRule()
                                        {
                                            Phrase = phrase
                                        });
                                        break;
                                    default:
                                        throw new XmlSchemaException();
                                }
                            }
                            switch (questionElement.GetAttribute("rule-validation"))
                            {
                                case "all":
                                    inputQuestion.RuleValidation = Rule.RuleValidationOption.All;
                                    break;
                                case "any":
                                    inputQuestion.RuleValidation = Rule.RuleValidationOption.Any;
                                    break; ;
                                default:
                                    throw new XmlSchemaException();
                            }
                            questions.Add(inputQuestion);
                            break;

                        default:
                            throw new XmlSchemaException();
                    }
                }
                problems.Add(new Problem()
                {
                    Text = problemElement.GetAttribute("text"),
                    Questions = questions
                });
            }

            return problems;
        }
    }
}
