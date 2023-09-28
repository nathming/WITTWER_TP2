using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WITTWER_TP2.Models;
using WITTWER_TP2.Services;
using WITTWER_TP2.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WITTWER_TP2.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        private AppModel _selectedApp;

        public ObservableCollection<AppModel> Applications { get; }

        public DAO_Passwd daopasswd;

        public Command LoadAppCommand { get; }

        public Command OnAddClickedCommand { get; }

        public Command<AppModel> AppTapped { get; }
        

        public WelcomeViewModel()
        {
            daopasswd = new DAO_Passwd();

            Applications = new ObservableCollection<AppModel>();

            LoadAppCommand = new Command(async () => await ExecuteLoadAppCommand());

            OnAddClickedCommand = new Command(OnAddClicked);

            AppTapped = new Command<AppModel>(OnItemSelected);


            //var application = await daopasswd.GetAppModelAsync(true);

            //GetAllApps();
        }

        async void OnItemSelected(AppModel appmodel)
        {
            if (appmodel == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            await Shell.Current.GoToAsync($"{nameof(InfoPswdPage)}?{nameof(InfoPswdViewModel.AppId)}={appmodel.Id}");
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }

        private async void OnAddClicked(object obj)
        {
            await Shell.Current.GoToAsync($"{nameof(AddPswdPage)}");
        }


        async Task ExecuteLoadAppCommand() //this function executer and put the data that we use in our program for the app
        {
            IsBusy = true;

            try
            {
                Applications.Clear();
                var application = await daopasswd.GetAllApp();
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
        

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedApp = null;
        }
        public AppModel SelectedApp
        {
            get => _selectedApp;
            set
            {
                SetProperty(ref _selectedApp, value);
                OnItemSelected(value);
            }
        }


    }
}
