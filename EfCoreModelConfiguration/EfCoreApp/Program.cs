using System.Linq;
using System;
using static System.Console;

using Microsoft.EntityFrameworkCore;
using EfCoreApp.EfCoreData;

namespace EfCoreApp
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var connectionString = @"server=DESKTOP-N3FG38H\KRAMSERVER;database=Stores;Integrated Security=SSPI;";
            GetProducts(connectionString);
            ReadKey();
        }

        public static void GetProducts(string connectionString){
            Clear();
            WriteLine("Products List");
            WriteLine("================================");
            using (var db = new StoreDbContext(connectionString)){
                    var products = db.Products.AsNoTracking().ToList();
                    products.ForEach(WriteLine);
            }
        }
    }
}
