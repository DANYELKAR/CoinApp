using CoinApp.Database;
using CoinApp.Models;
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
    public partial class FavoritesPage : ContentPage
    {
        ObservableCollection<Coin> observableList;

        public FavoritesPage()
        {
            InitializeComponent();
            observableList = new ObservableCollection<Coin>();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            loading.IsRunning = true;
            observableList.Clear();
            var favCoins = await SQLiteDatabase.GetFavoritesCoinsAsync();
            foreach (var item in favCoins)
            {
                observableList.Add(item);
            }
            favListView.ItemsSource = observableList;
            loading.IsRunning = false;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            Coin coin = (Coin)button.CommandParameter;
            int result = await SQLiteDatabase.DeleteCoinAsync(coin);
            if (result == 1)
            {
                await DisplayAlert("Successful", "Succesfully deleted to fav", "OK");
                observableList.Remove(coin);
            }
            else
            {
                await DisplayAlert("Error", "Something went wrong", "OK");
            }
        }
    }
}