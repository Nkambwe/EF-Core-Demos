using System;
using System.Collections.Generic;

namespace EfCoreApp.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public Guid? StoreId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        private ICollection<Order> _orders;
        public ICollection<Order> Orders
        {
            get => _orders ?? (_orders = new List<Order>());
            set => _orders = value;
        }
    }
}
