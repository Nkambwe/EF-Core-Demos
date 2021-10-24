using System;

namespace EfCoreAp.EfCoreEntities
{
    public class Product
    {
        public long Id {get;set;}
        public string Code {get;set;}
        public string Name {get; set; }
        public decimal PurchasePrice { get;set; }
        public decimal RetailPrice {get; set; }

        public override string ToString() => $"{Name.Trim()} - {PurchasePrice.ToString("#,###.##")}";
        public override int GetHashCode() => ToString().GetHashCode() ^ 3;
    }
}
