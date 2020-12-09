using System.ComponentModel;
using TuTasa.ViewModels;
using Xamarin.Forms;

namespace TuTasa.Views
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