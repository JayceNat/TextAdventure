using TextAdventure.ViewModels;
using Xamarin.Forms;

namespace TextAdventure.Views
{
    public partial class CharacterCreationPage : ContentPage
    {
        public CharacterCreationPage()
        {
            InitializeComponent();
            BindingContext = new CharacterCreationViewModel();
        }
    }
}