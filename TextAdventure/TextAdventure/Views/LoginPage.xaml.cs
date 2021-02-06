using TextAdventure.ViewModels;
using Xamarin.Forms;

namespace TextAdventure.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}