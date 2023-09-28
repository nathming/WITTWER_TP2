using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WITTWER_TP2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WITTWER_TP2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();

            TB_EmailLGP.Text = ""; //reset entry
            TB_PasswdLGP.Text = "";
        }
    }
}