using System;
using System.Collections.Generic;

namespace EfCoreApp.Entities
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private ICollection<Order> _orders;
        public ICollection<Order> Orders
        {
            get => _orders ?? (_orders = new List<Order>());
            set => _orders = value;
        }
    }
}
