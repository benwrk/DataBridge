using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Data.Models.Clues;

namespace Data
{
    public class ClueXmlParser
    {
        public static List<Clue> GetClues(int level)
        {
            var xmlDocument = new XmlDocument();
<<<<<<< HEAD
            xmlDocument.Load(XmlReader.Create(Constants.XmlParser.Clues.ConfigFilePath, new XmlReaderSettings()
            {
                IgnoreComments = true
            }));
=======
            var xmlReader = XmlReader.Create(Constants.XmlParser.Clues.ConfigFilePath, new XmlReaderSettings
            {
                IgnoreComments = true
            });
            xmlDocument.Load(xmlReader);
>>>>>>> 0d3b785481d210b5349401d39d37a4aff545d706

            var levels = xmlDocument.GetElementsByTagName(Constants.XmlParser.Clues.LevelTagName);
            var selectedLevel = levels[level - 1];

            return selectedLevel.ChildNodes.Cast<XmlElement>()
                .Select(clueElement => new Clue
                {
                    Text = clueElement.GetAttribute(Constants.XmlParser.Clues.TextAttributeName)
                }).ToList();
        }
    }
}