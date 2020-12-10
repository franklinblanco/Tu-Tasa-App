﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuTasa.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        private void MenuGoHome(object sender, EventArgs args)
        {
            //Navigation.PushAsync(new PricesPage());
        }
        private void MenuGoSettings(object sender, EventArgs args)
        {
            Navigation.PushAsync(new SettingsPage());
        }
        private void MenuGoPrices(object sender, EventArgs args)
        {
            Navigation.PushAsync(new PricesPage());
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}