using System;
using System.Collections.Generic;
using System.ComponentModel;
using WITTWER_TP2.Models;
using WITTWER_TP2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WITTWER_TP2.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}