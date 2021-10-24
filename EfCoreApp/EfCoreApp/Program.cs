using static System.Console;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using EfCoreApp.Data;

namespace EfCoreApp
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var connectionString = @"server=DESKTOP-N3FG38H\KRAMSERVER;database=Zza;Integrated Security=SSPI;";
            //GetTopThreeClients(connectionString);
            UpdateAddress(connectionString);
            ReadKey();
        }

        public static void GetTopThreeClients(string connectionString)
        {
            Clear();
            using (var db = new ZzaContext(connectionString))
            {
                //..get readonly reacords using AsNoTracking() method
                foreach (var customer in db.Customers.AsNoTracking().Include("Orders").Take(3))
                {
                    WriteLine($"{customer.FirstName.Trim()} {customer.LastName.Trim()} {customer.Email.Trim()}");
                    WriteLine("Orders");
                    WriteLine("===============");
                    foreach (var order in customer.Orders)
                    {
                        WriteLine($"\n{order.DeliveryDate.ToShortDateString()} USD.{order.DeliveryCharge.ToString("#,###")} {order.ItemsTotal.ToString()}");
                    }
                    WriteLine("===============");
                }
            }

        }

        public static void UpdateAddress(string connectionString)
        {
            Clear();
            using (var db = new ZzaContext(connectionString))
            {
                var orders = db.Orders.Where(order => order.CustomerId.Equals(new Guid("7462C7C8-E24C-484A-8F93-013F1C479615")));
                WriteLine("Orders before Update");
                foreach (var order in orders)
                {
                    WriteLine($"{order.OrderStatusId.ToString()}{order.DeliveryDate.ToShortDateString()} {order.DeliveryStreet ?? ""} {order.ItemsTotal.ToString()}");
                }

                WriteLine("Enter new address : ");
                var address = ReadLine();

                if(string.IsNullOrEmpty(address))
                    WriteLine("Invalid Address!");
                else{
                    foreach (var order in orders)
                        order.DeliveryStreet = address.Trim();
                    
                    db.SaveChanges();

                    //list orders
                    WriteLine("Orders after Update");
                    foreach (var order in orders)
                    {
                        WriteLine($"{order.OrderStatusId.ToString()}{order.DeliveryDate.ToShortDateString()} {order.DeliveryStreet ?? ""} {order.ItemsTotal.ToString()}");
                    }
                }

            }
        }
    }
}
