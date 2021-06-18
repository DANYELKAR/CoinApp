using CoinApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CoinApp.Database
{
    public class SQLiteDatabase
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
            {
                return;
            }
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Coins.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Coin>();
        }
        public static async Task<List<Coin>> GetFavoritesCoinsAsync()
        {
            await Init();
            var coins = await db.Table<Coin>().ToListAsync();
            return coins;
        }

        public static async Task<int> InsertCoinAsync(Coin coin)
        {
            await Init();
            return await db.InsertAsync(coin);
        }

        public static async Task<int> DeleteCoinAsync(Coin coin)
        {
            await Init();
            return await db.DeleteAsync(coin);
        }
    }
}
