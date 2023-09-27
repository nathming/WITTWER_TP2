using System;
using System.Collections.Generic;
using WITTWER_TP2.ViewModels;
using WITTWER_TP2.Views;
using Xamarin.Forms;

namespace WITTWER_TP2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(InfoPswdPage), typeof(InfoPswdPage));
            Routing.RegisterRoute(nameof(AddPswdPage), typeof(AddPswdPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
