using TextAdventure.ViewModels;
using Xamarin.Forms;

namespace TextAdventure.Views
{
    public partial class MainGamePage : ContentPage
    {
        public MainGamePage()
        {
            InitializeComponent();
            BindingContext = new MainGameViewModel();
        }

        private void Editor_Focused(object sender, FocusEventArgs e)
        {
            // Complete the Room Typing
        }
    }
}