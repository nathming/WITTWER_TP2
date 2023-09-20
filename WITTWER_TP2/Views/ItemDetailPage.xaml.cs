using System.ComponentModel;
using WITTWER_TP2.ViewModels;
using Xamarin.Forms;

namespace WITTWER_TP2.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}