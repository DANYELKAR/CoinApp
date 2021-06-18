using CoinApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinApp.Service
{
    public class NomicsApiService
    {
        const string BASE_URL = "https://api.nomics.com/v1/exchange-rates?key=";
        const string API_KEY = "bc5458fe07a9a1d40d4b7bfa696dfc6ddd36ac5d";

        HttpClient client;

        public NomicsApiService()
        {
            client = new HttpClient();
        }

        public async Task<List<Coin>> GetAllCoinsAsync()
        {
            var result = await client.GetStringAsync(BASE_URL+API_KEY);
            var coins = JsonConvert.DeserializeObject<List<Coin>>(result);
            return coins;
        }
    }
}
