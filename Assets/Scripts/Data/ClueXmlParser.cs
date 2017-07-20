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
            xmlDocument.Load(XmlReader.Create(Constants.XmlParser.Clues.ConfigFilePath, new XmlReaderSettings()
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
    }
}