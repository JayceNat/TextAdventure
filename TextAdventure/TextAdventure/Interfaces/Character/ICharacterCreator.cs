namespace TextAdventure.Interfaces.Character
{
    public interface ICharacterCreator
    {
        // Declare all getters for any Characters you will use here
        Models.Character.Character Player { get; set; }
        Models.Character.Character Charlie { get; set; }
        Models.Character.Character Henry { get; set; }
        Models.Character.Character Ghoul { get; set; }
    }
}
