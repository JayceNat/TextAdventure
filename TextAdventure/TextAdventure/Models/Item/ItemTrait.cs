using System.Xml.Serialization;

namespace TextAdventure.Models.Item
{
    public class ItemTrait
    {
        [XmlElement("nom")]
        public string TraitName { get; set; }

        [XmlElement("reltrib")]
        public string RelevantCharacterAttribute { get; set; }

        [XmlElement("v")]
        public int TraitValue { get; set; }
    }
}
