using System;
using WITTWER_TP2.Services;
using WITTWER_TP2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WITTWER_TP2
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
