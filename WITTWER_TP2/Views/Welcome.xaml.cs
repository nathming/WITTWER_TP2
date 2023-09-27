using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WITTWER_TP2.ViewModels;

namespace WITTWER_TP2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Welcome : ContentPage
    {
        WelcomeViewModel _viewModel;

        public Welcome()
        {
            InitializeComponent();
            BindingContext = _viewModel = new WelcomeViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        private void Button_SizeChanged(object sender, EventArgs e)
        {

        }

        
    }
}