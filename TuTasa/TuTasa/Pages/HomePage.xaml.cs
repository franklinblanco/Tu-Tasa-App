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
    public partial class HomePage : ContentPage
    {
        public IList<Rate> AllRates { get; private set; }
        public HomePage()
        {
            InitializeComponent();
            //SetHomePageData();
            PopulateTable();
        }
        void SetHomePageData()
        {
            string wholePage = ConnectionManager.Instance.AskForHomePage();
            Console.WriteLine("Whole msg is: " + wholePage);
            string[] Items = wholePage.Split('/');

            AllRates = new List<Rate>();
            for (int x = 0; x < Items.Length; x++)
            {
                string[] data = Items[x].Split('-');
                AllRates.Add(new Rate
                {
                    bankname = data[0],
                    currency = data[1],
                    buyrate = data[2],
                    sellrate = data[3]
                });
            }
            BindingContext = this;
        }

        void PopulateTable()
        {
            string wholePage = ConnectionManager.Instance.AskForHomePage();
            Console.WriteLine("Whole msg is: " + wholePage);
            string[] Items = wholePage.Split('/');

            //The title grid
            Grid firstCell = new Grid
            {
                ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) }
                        //Add one extra for the date, maybe?
                    },
            };

            Label banktitleex = new Label
            {
                Text = "Banco",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center
            };
            Label currencytitleex = new Label
            {
                Text = "Moneda",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center
            };
            Label buypriceex = new Label
            {
                Text = "Compra",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center
            };
            Label sellpriceex = new Label
            {
                Text = "Venta",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center
            };

            firstCell.Children.Add(banktitleex, 0, 0);
            firstCell.Children.Add(currencytitleex, 1, 0);
            firstCell.Children.Add(buypriceex, 2, 0);
            firstCell.Children.Add(sellpriceex, 3, 0);

            TableContainer.Children.Add(firstCell);

            BoxView separatorLine = new BoxView
            {
                HeightRequest = 1,
                BackgroundColor = Color.Black
            };

            TableContainer.Children.Add(separatorLine);

            for (int x = 0; x < Items.Length; x++)
            {
                string[] data = Items[x].Split('-');
                Grid cell = new Grid
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) }
                        //Add one extra for the date, maybe?
                    },
                };

                Label banktitle = new Label
                {
                    Text = data[0],
                    FontSize = 17,
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center
                };
                Label currencytitle = new Label
                {
                    Text = data[1],
                    FontSize = 17,
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center
                };
                Label buyprice = new Label
                {
                    Text = data[2],
                    FontSize = 17,
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center
                };
                Label sellprice = new Label
                {
                    Text = data[3],
                    FontSize = 17,
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center
                };

                cell.Children.Add(banktitle, 0, 0);
                cell.Children.Add(currencytitle, 1, 0);
                cell.Children.Add(buyprice, 2, 0);
                cell.Children.Add(sellprice, 3, 0);

                TableContainer.Children.Add(cell);
            }
        }
        private void MenuGoHome(object sender, EventArgs args)
        {
            //Navigation.PushAsync(new HomePage());
        }
        private void MenuGoSettings(object sender, EventArgs args)
        {
            Navigation.PushAsync(new SettingsPage());
        }
        private void MenuGoPrices(object sender, EventArgs args)
        {
            //Navigation.PushAsync(new HomePage());
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}