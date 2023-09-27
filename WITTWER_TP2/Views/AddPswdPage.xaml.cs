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
        }
    }
}