using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using WITTWER_TP2.Models;
using Xamarin.Forms;

namespace WITTWER_TP2.ViewModels
{
    [QueryProperty(nameof(AppId), nameof(AppId))]
    public class InfoPswdViewModel : BaseViewModel
    {

        private string appId;
        private string apptext;
        private string appdescription;
        public string Idgen { get; set; }

        public string AppText
        {
            get => apptext;
            set => SetProperty(ref apptext, value);
        }

        public string AppDescription
        {
            get => appdescription;
            set => SetProperty(ref appdescription, value);
        }

        public string AppId
        {
            get
            {
                return appId;
            }
            set
            {
                appId = value;
                LoadAppId(value);
            }
        }

        public async void LoadAppId(string appId)
        {
            try
            {
                var app = await DataStore.GetItemAsync(appId);
                Idgen = app.Id;
                AppText = app.Text;
                AppDescription = app.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
