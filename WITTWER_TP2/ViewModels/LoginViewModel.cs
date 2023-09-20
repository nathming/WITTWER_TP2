using System;
using System.Collections.Generic;
using System.Text;
using WITTWER_TP2.Views;
using Xamarin.Forms;

namespace WITTWER_TP2.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public string Email { get; set; }
        public string Passwd { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            if (Email == "a.j@gm.co" && Passwd == "21")
            {
                await Shell.Current.GoToAsync($"//{nameof(Welcome)}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Erreur", "Nom d'utilisateur ou mot de passe incorrect.", "OK");
            }
        }
    }
}
