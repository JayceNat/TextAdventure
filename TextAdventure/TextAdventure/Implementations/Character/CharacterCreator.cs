using TextAdventure.GameEntities.Character;
using TextAdventure.Interfaces.Character;

namespace TextAdventure.Implementations.Character
{
    public class CharacterCreator : ICharacterCreator
    {
        // Declare all getters for any Characters you will use here
        public Models.Character.Character Player { get; set; }
        public Models.Character.Character Charlie { get; set; }
        public Models.Character.Character Henry { get; set; }
        public Models.Character.Character Ghoul { get; set; }

        // Constructor: Add the reference to all the Attribute Objects here
        public CharacterCreator()
        {
            Player = Characters.Player;
            Charlie = Characters.Charlie;
            Henry = Characters.Henry;
            Ghoul = Characters.Ghoul;
        }
    }
}
