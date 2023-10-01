using System;
using System.Collections.Generic;
using System.Text;
using WITTWER_TP2.Models;
using WITTWER_TP2.Views;
using Xamarin.Forms;
using WITTWER_TP2.Services;

using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections.Specialized;

namespace WITTWER_TP2.ViewModels
{
    public class AddPswdViewModel : BaseViewModel
    {
        public DAO_Passwd dao_passwd;
        public Command DoneApp { get; }
        public Command QuitPage { get; }


        public string Bbd_TB_AddAppName { get; set; }
        public string Bbd_TB_AddAppUsername { get; set; }
        public string Bbd_TB_AddAppPassword { get; set; }


        public AddPswdViewModel()
        {
            dao_passwd = new DAO_Passwd();
            DoneApp = new Command(OnDoneAppClicked);
            QuitPage = new Command(OnQuitPageClicked);

        }

        private async void OnDoneAppClicked(object obj)
        {
            if (dao_passwd.AddItemAsync(Bbd_TB_AddAppName, Bbd_TB_AddAppPassword, Bbd_TB_AddAppUsername).Result == false)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "failed to add the app", "OK");
            }

            await Shell.Current.GoToAsync($"//{nameof(Welcome)}");
        }

        private async void OnQuitPageClicked(object obj)
        {

            await Shell.Current.GoToAsync($"//{nameof(Welcome)}");
        }




        

        public static string txtchdfindsecurity(string password)
        {
            int score = 0;
            string comment = "";

            // minimal length
            if (password.Length >= 8)
            {
                score++;
            }


            // check if there is some numbers
            if (Regex.IsMatch(password, @"\d"))
            {
                score++;
            }

            // check f there is a capital caracter
            if (Regex.IsMatch(password, @"[A-Z]"))
            {
                score++;
            }

            // check if there is come caracters
            if (Regex.IsMatch(password, @"[a-z]"))
            {
                score++;
            }

            // check for special caracter
            if (Regex.IsMatch(password, @"[^a-zA-Z0-9]"))
            {
                score++;
            }

            //setting extrem minimal length
            if (password.Length <= 4)
            {
                score = 0;
            }

            switch (score)
            {
                case 0:
                    comment = "Very weak password";
                    break;
                case 1:
                    comment = "Weak password";
                    break;
                case 2:
                    comment = "Quite strong password";
                    break;
                case 3:
                    comment = "Strong password";
                    break;
                case 4:
                    comment = "Very strong password";
                    break;
            }

            return comment;
        }
        



    }
}
