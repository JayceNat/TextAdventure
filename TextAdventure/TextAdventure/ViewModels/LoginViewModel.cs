using TextAdventure.Views;
using Xamarin.Forms;

namespace TextAdventure.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command ContinueGameCommand { get; }
        public Command NewGameCommand { get; }

        public LoginViewModel()
        {
            ContinueGameCommand = new Command(OnContinueClicked);
            NewGameCommand = new Command(OnNewGameClicked);
        }

        private async void OnContinueClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(MainGamePage)}");
        }

        private async void OnNewGameClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(CharacterCreationPage)}");
        }
    }
}
