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
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(XmlReader.Create(Constants.XmlParser.Problems.ConfigFilePath, new XmlReaderSettings()
            {
                IgnoreComments = true
            }));


            var levels = xmlDocument.GetElementsByTagName(Constants.XmlParser.Problems.LevelTagName);
            var selectedLevel = levels[level - 1];

            var problems = new List<Problem>();

            foreach (XmlElement problemElement in selectedLevel.ChildNodes)
            {
                var questions = new List<Question>();
                foreach (XmlElement questionElement in problemElement.ChildNodes)
                {
                    switch (questionElement.Name)
                    {
                        case Constants.XmlParser.Problems.ChoiceQuestionTagName:
                            var choiceQuestion = new ChoiceQuestion()
                            {
                                Text = questionElement.GetAttribute(Constants.XmlParser.Problems.TextAttributeName),
                                Choices = new List<Choice>()
                            };
                            foreach (XmlElement choiceElement in questionElement.ChildNodes)
                            {
                                choiceQuestion.Choices.Add(new Choice()
                                {
                                    Text = choiceElement.GetAttribute(Constants.XmlParser.Problems.TextAttributeName),
                                    IsCorrect = choiceElement.HasAttribute("correct") && choiceElement.GetAttribute("correct").Equals("true")
                                });
                            }
                            questions.Add(choiceQuestion);
                            break;

                        case Constants.XmlParser.Problems.InputQuestionTagName:
                            var inputQuestion = new InputQuestion()
                            {
                                Text = questionElement.GetAttribute(Constants.XmlParser.Problems.TextAttributeName),
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
                                    break;
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
                    Text = problemElement.GetAttribute(Constants.XmlParser.Problems.TextAttributeName),
                    Questions = questions
                });
            }

            return problems;
        }
    }
}
