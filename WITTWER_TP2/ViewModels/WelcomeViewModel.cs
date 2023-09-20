using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WITTWER_TP2.Models;
using WITTWER_TP2.Services;
using Xamarin.Forms;

namespace WITTWER_TP2.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {

        public ObservableCollection<AppModel> Applications { get; }

        public DAO_Passwd daopasswd;

        public Command LoadAppCommand { get; }

        public WelcomeViewModel()
        {
            daopasswd = new DAO_Passwd();

            Applications = new ObservableCollection<AppModel>();

            LoadAppCommand = new Command(async () => await ExecuteLoadAppCommand());

            //var application = await daopasswd.GetAppModelAsync(true);

            //GetAllApps();
        }

        async Task ExecuteLoadAppCommand()
        {
            IsBusy = true;

            try
            {
                Applications.Clear();
                var application = await daopasswd.GetAppModel(true);
                foreach (var app in application)
                {
                    Applications.Add(app);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }



        public async void GetAllApps()
        {
            var application = await daopasswd.GetAppModel(true);
            foreach (var app in application)
            {
                Applications.Add(app);
            }
        }


        
    }
}
