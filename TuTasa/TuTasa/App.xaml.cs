using System;
using TuTasa.Pages;
using TuTasa.Services;
using TuTasa.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuTasa
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new SplashScreen());
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
