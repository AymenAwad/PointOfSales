using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class Catogery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }
        public int? ItemsId { get; set; }
        public int? StoseQuantitiesId { get; set; }
        public int? StoreReturnedsId { get; set; }
        public int? SalesInformationId { get; set; }
        public int? SupplimentInformationId { get; set; }

        public virtual Item Items { get; set; }
        public virtual SalesInformation SalesInformation { get; set; }
        public virtual StoreReturned StoreReturneds { get; set; }
        public virtual StoreQuantity StoseQuantities { get; set; }
        public virtual SupplimentInformation SupplimentInformation { get; set; }
    }
}
