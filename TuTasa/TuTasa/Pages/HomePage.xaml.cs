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
        public HomePage()
        {
            InitializeComponent();
            //SetHomePageData();
            PopulateTable();
        }

        void PopulateTable()
        {

            Rate[] rates = CacheManager.Instance.GetCurrencies();
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
            Button sortbuybtn = new Button
            {
                BackgroundColor = Color.Transparent,
            };
            sortbuybtn.Clicked += SortByBuyPrice;

            Button sortsellbutton = new Button
            {
                BackgroundColor = Color.Transparent,
            };
            sortsellbutton.Clicked += SortBySellPrice;


            firstCell.Children.Add(banktitleex, 0, 0);
            firstCell.Children.Add(currencytitleex, 1, 0);
            firstCell.Children.Add(buypriceex, 2, 0);
            firstCell.Children.Add(sellpriceex, 3, 0);

            //Add buttons for Compra y venta (Sorting)
            firstCell.Children.Add(sortbuybtn, 2, 0);
            firstCell.Children.Add(sortsellbutton, 3, 0);

            TableContainer.Children.Add(firstCell);

            BoxView separatorLine = new BoxView
            {
                HeightRequest = 1,
                BackgroundColor = Color.Black
            };

            TableContainer.Children.Add(separatorLine);

            for (int x = 0; x < rates.Length; x++)
            {
                Rate rate = rates[x];
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
                    Text = rate.bankname,
                    FontSize = 17,
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center
                };
                Label currencytitle = new Label
                {
                    Text = rate.currency,
                    FontSize = 17,
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center
                };
                Label buyprice = new Label
                {
                    Text = rate.buyrate,
                    FontSize = 17,
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center
                };
                Label sellprice = new Label
                {
                    Text = rate.sellrate,
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
        private void SortByBuyPrice(object sender, EventArgs args)
        {
            CacheManager.Instance.SortBy("buyprice");
            ClearTable();
            PopulateTable();
        }
        private void SortBySellPrice(object sender, EventArgs args)
        {
            CacheManager.Instance.SortBy("sellprice");
            PopulateTable();
        }
        private void ClearTable()
        {
            TableContainer.Children.Clear();
        }

    }
}