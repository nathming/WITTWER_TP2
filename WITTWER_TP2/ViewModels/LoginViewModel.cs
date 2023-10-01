using System;
using System.Collections.Generic;
using System.Text;
using WITTWER_TP2.Views;
using Xamarin.Forms;

using WITTWER_TP2.Services;

namespace WITTWER_TP2.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public DAO_Passwd dao_passwd; //call of dao password

        public Command LoginCommand { get; }

        public string Email { get; set; }
        public string Passwd { get; set; }

        public LoginViewModel()
        {
            dao_passwd = new DAO_Passwd(); //call of dao password

            LoginCommand = new Command(OnLoginClicked);

        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            if (BitConverter.ToString(DAO_Passwd.Encrypt(Passwd)).Replace("-", "") == "D4FF7B2265C53C5EC3EA5F38651BDBD7" && Email == "a.j@gm.co") //if we adapt the database we can then compare with the user init and the crypted text directly in the database
            {
                await Shell.Current.GoToAsync($"//{nameof(Welcome)}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "incorect Password or Email (try jlp as password)", "OK");
            }
        }
    }
}
