using System;
using System.Collections.Generic;

namespace EfCoreApp.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool HasOptions { get; set; }
        public bool IsVegetarian { get; set; }
        public bool WithTomatoSauce { get; set; }
        public string SizeIds { get; set; }

        private ICollection<OrderItem> _items;
        public ICollection<OrderItem> Items
        {
            get => _items ?? (_items = new List<OrderItem>());
            set => _items = value;
        }
    }
}
