using CoinApp.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DictionaryPage : ContentPage
    {
        DictionaryAPIService service = new DictionaryAPIService();
        public DictionaryPage()
        {
            InitializeComponent();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var response = await service.GetAllDictionaryAsync();
            Console.WriteLine(response);

        }
    }
}