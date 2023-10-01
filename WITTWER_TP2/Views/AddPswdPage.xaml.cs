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
    public partial class AddPswdPage : ContentPage
    {
        public AddPswdPage()
        {
            InitializeComponent();
            this.BindingContext = new AddPswdViewModel();

            TB_AddAppName.Text = ""; //reset entry
            TB_AddAppPassword.Text = "";
            TB_AddAppUsername.Text = "";
        }

        private void txtchd(object sender, TextChangedEventArgs e)
        {
            // Obtenir le texte actuel de l'Entry
            string newText = e.NewTextValue;

            LB_PswdComment.Text =  AddPswdViewModel.txtchdfindsecurity(newText);
        }


    }
}