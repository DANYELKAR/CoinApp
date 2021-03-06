using CoinApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoinApp.Service
{
    public class DictionaryAPIService
    {
        const string BASE_URL = "https://raw.githubusercontent.com/DANYELKAR/CoinApp/master/CoinApp/CoinApp/JsonDictionary/coinDictionary.json";

        HttpClient client;

        public DictionaryAPIService()
        {
            client = new HttpClient();
        }

        public async Task<List<CoinDictionary>> GetAllDictionaryAsync()
        {
            var result = await client.GetStringAsync(BASE_URL);
            var dictionary = JsonConvert.DeserializeObject<List<CoinDictionary>>(result);
            return dictionary;
        }
    }
}
