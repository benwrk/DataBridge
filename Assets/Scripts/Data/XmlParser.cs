using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using Data.Models.Clues;
using Data.Models.Problems;

namespace Data
{
    public static class XmlParser
    {
        public static IList<Clue> GetClues(int level)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(XmlReader.Create(Constants.XmlParser.Clues.ConfigFilePath, new XmlReaderSettings
            {
                IgnoreComments = true
            }));

            var levels = xmlDocument.GetElementsByTagName(Constants.XmlParser.Clues.LevelTagName);
            var selectedLevel = levels[level - 1];

            return selectedLevel.ChildNodes.Cast<XmlElement>()
                .Select(clueElement => new Clue
                {
                    Text = clueElement.GetAttribute(Constants.XmlParser.Clues.TextAttributeName)
                }).ToList();
        }

        public static IList<Problem> GetProblems(int level)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(XmlReader.Create(Constants.XmlParser.Problems.ConfigFilePath, new XmlReaderSettings
            {
                IgnoreComments = true
            }));

            var levels = xmlDocument.GetElementsByTagName(Constants.XmlParser.Problems.LevelTagName);
            var selectedLevel = levels[level - 1];

            var problems = new List<Problem>();

            foreach (XmlElement problemElement in selectedLevel.ChildNodes)
            {
                var problemText = problemElement.GetAttribute(Constants.XmlParser.Problems.TextAttributeName);

                switch (problemElement.Name)
                {
                    case Constants.XmlParser.Problems.ChoiceProblemTagName:
                        var choiceProblem = new ChoiceProblem
                        {
                            Text = problemText,
                            Questions = new List<ChoiceQuestion>()
                        };

                        problems.Add(choiceProblem);

                        foreach (XmlElement choiceQuestionElement in problemElement.ChildNodes)
                        {
                            var choiceQuestion = new ChoiceQuestion
                            {
                                Text = choiceQuestionElement.GetAttribute(
                                    Constants.XmlParser.Problems.TextAttributeName),
                                Choices = new List<Choice>()
                            };

                            choiceProblem.Questions.Add(choiceQuestion);

                            foreach (XmlElement choiceElement in choiceQuestionElement.ChildNodes)
                                choiceQuestion.Choices.Add(new Choice
                                {
                                    Text = choiceElement.GetAttribute(Constants.XmlParser.Problems.TextAttributeName),
                                    IsCorrect =
                                        choiceElement.HasAttribute(Constants.XmlParser.Problems
                                            .IsCorrectAttributeName) &&
                                        choiceElement.GetAttribute(Constants.XmlParser.Problems.IsCorrectAttributeName)
                                            .Equals("true")
                                });
                        }

                        break;

                    case Constants.XmlParser.Problems.InputProblemTagName:
                        var inputProblem = new InputProblem
                        {
                            Text = problemText,
                            Questions = new List<InputQuestion>()
                        };

                        problems.Add(inputProblem);

                        foreach (XmlElement inputQuestionElement in problemElement.ChildNodes)
                        {
                            var inputQuestion = new InputQuestion
                            {
                                Text =
                                    inputQuestionElement.GetAttribute(Constants.XmlParser.Problems.TextAttributeName),
                                Placeholder =
                                    inputQuestionElement.GetAttribute(Constants.XmlParser.Problems
                                        .PlaceholderAttributeName),
                                Rules = new List<Rule>()
                            };

                            inputProblem.Questions.Add(inputQuestion);

                            foreach (XmlElement ruleElement in inputQuestionElement.ChildNodes)
                            {
                                var phrase = ruleElement.GetAttribute(Constants.XmlParser.Problems.PhraseAttributeName);

                                switch (ruleElement.Name)
                                {
                                    case Constants.XmlParser.Problems.MatchesRuleTagName:
                                        inputQuestion.Rules.Add(new MatchesRule
                                        {
                                            Phrase = phrase
                                        });
                                        break;

                                    case Constants.XmlParser.Problems.ContainsRuleTagName:
                                        inputQuestion.Rules.Add(new ContainsRule
                                        {
                                            Phrase = phrase
                                        });
                                        break;

                                    case Constants.XmlParser.Problems.WithoutRuleTagName:
                                        inputQuestion.Rules.Add(new WithoutRule
                                        {
                                            Phrase = phrase
                                        });
                                        break;

                                    default:
                                        throw new XmlSchemaException(Constants.XmlParser.XmlSchemaExceptionMessage);
                                }
                            }

                            switch (inputQuestionElement.GetAttribute(Constants.XmlParser.Problems
                                .RuleValidationOptionAttributeName))
                            {
                                case Constants.XmlParser.Problems.ValidateAllAttributeValue:
                                    inputQuestion.RuleValidation = Rule.RuleValidationOption.All;
                                    break;

                                case Constants.XmlParser.Problems.ValidateAnyAttributeValue:
                                    inputQuestion.RuleValidation = Rule.RuleValidationOption.Any;
                                    break;

                                default:
                                    throw new XmlSchemaException(Constants.XmlParser.XmlSchemaExceptionMessage);
                            }
                        }
                        break;

                    default:
                        throw new XmlSchemaException(Constants.XmlParser.XmlSchemaExceptionMessage);
                }
            }

            return problems;
        }
    }
}