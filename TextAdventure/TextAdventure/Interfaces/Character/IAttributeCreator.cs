using TextAdventure.Models.Character;

namespace TextAdventure.Interfaces.Character
{
    public interface IAttributeCreator
    {
        // Declare all getters for any Character Attributes you will use here
        CharacterAttribute PlayerAttributes { get; }
        CharacterAttribute CharlieAttributes { get; }
        CharacterAttribute HenryAttributes { get; }
        CharacterAttribute GhoulAttributes { get; }
    }
}
