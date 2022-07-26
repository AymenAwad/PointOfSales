using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }
        public int? ItemId { get; set; }
        public int? SalesInformationId { get; set; }
        public int? SupplimentInformationId { get; set; }

        public virtual Item Item { get; set; }
        public virtual SalesInformation SalesInformation { get; set; }
        public virtual SupplimentInformation SupplimentInformation { get; set; }
    }
}
