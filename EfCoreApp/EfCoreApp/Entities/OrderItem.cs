using System;

namespace EfCoreApp.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid? StoreId { get; set; }
        public long OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductSizeId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Instructions { get; set; }

        private Order _order;
        public virtual Order Order
        {
            get => _order ?? (_order = new Order());
            set => _order = value;
        }

        private Product _product;
        public virtual Product Product
        {
            get => _product ?? (_product = new Product());
            set => _product = value;
        }
        private ProductSize _size;
        public virtual ProductSize Size
        {
            get => _size ?? (_size = new ProductSize());
            set => _size = value;
        }

        private ProductOption _option;
        public virtual ProductOption Option
        {
            get => _option ?? (_option = new ProductOption());
            set => _option = value;
        }
    }
}
