using System;
using System.Collections.Generic;

namespace EfCoreApp.Entities
{
    public class Order
    {
        public long Id { get; set; }
        public Guid? StoreId { get; set; }
        public Guid CustomerId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Phone { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal DeliveryCharge { get; set; }
        public string DeliveryStreet { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryState { get; set; }
        public decimal ItemsTotal { get; set; }

        private Customer _customer;
        public virtual Customer Customer
        {
            get => _customer ?? (_customer = new Customer());
            set => _customer = value;
        }

        private OrderStatus _status;
        public virtual OrderStatus OrderStatus
        {
            get => _status ?? (_status = new OrderStatus());
            set => _status = value;
        }

        private ICollection<OrderItem> _items;
        public ICollection<OrderItem> Items
        {
            get => _items ?? (_items = new List<OrderItem>());
            set => _items = value;
        }
    }
}