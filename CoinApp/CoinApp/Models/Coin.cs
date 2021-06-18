using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinApp.Models
{
    public class Coin
    {
        [PrimaryKey]
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("rate")]
        public string Rate { get; set; }
    }
}
