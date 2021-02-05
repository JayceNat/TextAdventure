using System.ComponentModel;
using TextAdventure.ViewModels;
using Xamarin.Forms;

namespace TextAdventure.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}