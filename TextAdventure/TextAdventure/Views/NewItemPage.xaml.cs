using System;
using System.Collections.Generic;
using System.ComponentModel;
using TextAdventure.Models;
using TextAdventure.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TextAdventure.Views
{
    public partial class NewItemPage : ContentPage
    {
        public old_Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}