using TextAdventure.GameEntities.Character;
using TextAdventure.Interfaces.Character;
using TextAdventure.Models.Character;

namespace TextAdventure.Implementations.Character
{
    public class AttributeCreator : IAttributeCreator
    {
        // Declare all getters for any Character Attributes you will use here
        public CharacterAttribute PlayerAttributes { get; }
        public CharacterAttribute CharlieAttributes { get; }
        public CharacterAttribute HenryAttributes { get; }
        public CharacterAttribute GhoulAttributes { get; }

        // Constructor: Add the reference to all the Attribute Objects here
        public AttributeCreator()
        {
            PlayerAttributes = Attributes.PlayerAttributes;
            CharlieAttributes = Attributes.CharlieAttributes;
            HenryAttributes = Attributes.HenryAttributes;
            GhoulAttributes = Attributes.GhoulAttributes;
        }
    }
}
