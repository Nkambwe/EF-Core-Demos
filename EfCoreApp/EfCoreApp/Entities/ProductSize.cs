using System;
using System.Collections.Generic;

namespace EfCoreApp.Entities
{
    public class ProductSize
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? PremiumPrice { get; set; }
        public decimal? ToppingPrice { get; set; }
        public bool? IsGlutenFree { get; set; }

        private ICollection<OrderItem> _items;
        public ICollection<OrderItem> Items
        {
            get => _items ?? (_items = new List<OrderItem>());
            set => _items = value;
        }
    }
}
