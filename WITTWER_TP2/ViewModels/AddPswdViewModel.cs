using System;
using System.Collections.Generic;
using System.Text;
using WITTWER_TP2.Models;
using WITTWER_TP2.Views;
using Xamarin.Forms;
using WITTWER_TP2.Services;


namespace WITTWER_TP2.ViewModels
{
    public class AddPswdViewModel : BaseViewModel
    {
        public Command DoneApp { get; }
        public Command QuitPage { get; }

        public string Bbd_TB_AddAppName { get; set; }
        public string Bbd_TB_AddAppUsername { get; set; }
        public string Bbd_TB_AddAppPassword { get; set; }


        public AddPswdViewModel()
        {
            DoneApp = new Command(OnDoneAppClicked);
            QuitPage = new Command(OnQuitPageClicked);
        }

        private async void OnDoneAppClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(Welcome)}");
        }

        private async void OnQuitPageClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(Welcome)}");
        }

        
    }
}
