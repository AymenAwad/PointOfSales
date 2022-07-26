using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class StoreQuantity
    {
        public StoreQuantity()
        {
            AspNetUsers = new HashSet<AspNetUser>();
            Catogeries = new HashSet<Catogery>();
            Items = new HashSet<Item>();
            Stories = new HashSet<Story>();
        }

        public int Id { get; set; }
        public int StoreId { get; set; }
        public int CatogeryId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public int? LastUpdateBy { get; set; }
        public decimal SalePrice { get; set; }
        public decimal BuyPrice { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        public virtual ICollection<Catogery> Catogeries { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}
