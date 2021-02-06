using System.Xml.Serialization;
using TextAdventure.Models.Item;

namespace TextAdventure.Models.Shared
{
    public class ItemRequirement
    {
        [XmlElement("nom")]
        public string RequirementName { get; set; }

        [XmlElement("reli")]
        public InventoryItem RelevantItem { get; set; }
    }
}
