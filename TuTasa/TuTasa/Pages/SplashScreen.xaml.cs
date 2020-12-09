using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TuTasa.Scripts;

namespace TuTasa.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreen : ContentPage
    {
        public SplashScreen()
        {
            InitializeComponent();
            AttemptConnection();
        }
        private async void AttemptConnection()
        {
            await Task.Delay(1000);
            if (ConnectionManager.Instance.Connect())
            {
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}