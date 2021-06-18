using CoinApp.Database;
using CoinApp.Models;
using CoinApp.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoinListPage : ContentPage
    {
        NomicsApiService service = new NomicsApiService();
        ObservableCollection<Coin> observableList;
        public CoinListPage()
        {
            InitializeComponent();
            observableList = new ObservableCollection<Coin>();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            loading.IsRunning = true;
            observableList.Clear();
            var response = await service.GetAllCoinsAsync();
            foreach (var item in response)
            {
                observableList.Add(item);
            }
            coinListView.ItemsSource = observableList;
            loading.IsRunning = false;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            Coin coin = (Coin)button.CommandParameter;
            try
            {
                int result = await SQLiteDatabase.InsertCoinAsync(coin);
                if (result == 1)
                {
                    await DisplayAlert("Successful", "Succesfully added to fav", "OK");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Zaten var aq", "OK");
            }

        }
    }
}