using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class Item
    {
        public Item()
        {
            AspNetUsers = new HashSet<AspNetUser>();
            Catogeries = new HashSet<Catogery>();
            Units = new HashSet<Unit>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CatogeryId { get; set; }
        public int UnitId { get; set; }
        public string Image { get; set; }
        public decimal SalePrice { get; set; }
        public decimal BuyPrice { get; set; }
        public int? CreatedBy { get; set; }
        public string ItemCode { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }
        public int? StoreQuantitiesId { get; set; }
        public int? StoreReturnedId { get; set; }
        public int? SalesInformationId { get; set; }
        public int? SupplimentInformationId { get; set; }

        public virtual SalesInformation SalesInformation { get; set; }
        public virtual StoreQuantity StoreQuantities { get; set; }
        public virtual StoreReturned StoreReturned { get; set; }
        public virtual SupplimentInformation SupplimentInformation { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        public virtual ICollection<Catogery> Catogeries { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
