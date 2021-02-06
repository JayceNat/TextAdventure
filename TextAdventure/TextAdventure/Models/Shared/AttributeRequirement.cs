using System.Xml.Serialization;

namespace TextAdventure.Models.Shared
{
    public class AttributeRequirement
    {
        [XmlElement("nom")]
        public string RequirementName { get; set; }

        [XmlElement("reltrib")]
        public string RelevantCharacterAttribute { get; set; }

        [XmlElement("v")]
        public int MinimumAttributeValue { get; set; }
    }
}
