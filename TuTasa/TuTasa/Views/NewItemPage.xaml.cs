using System;
using System.Collections.Generic;
using System.ComponentModel;
using TuTasa.Models;
using TuTasa.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuTasa.Views
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