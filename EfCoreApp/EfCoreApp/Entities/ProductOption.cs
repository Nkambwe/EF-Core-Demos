using System;
using System.Collections.Generic;

namespace EfCoreApp.Entities
{
    public class ProductOption
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Factor { get; set; }
        public bool IsPizzaOption { get; set; }
        public bool IsSaladOption { get; set; }

        private ICollection<OrderItem> _items;
        public ICollection<OrderItem> Items
        {
            get => _items ?? (_items = new List<OrderItem>());
            set => _items = value;
        }
    }
}
