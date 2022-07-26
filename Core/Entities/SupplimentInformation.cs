using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class SupplimentInformation
    {
        public SupplimentInformation()
        {
            Catogeries = new HashSet<Catogery>();
            Items = new HashSet<Item>();
            Sales = new HashSet<Sale>();
            Suppliments = new HashSet<Suppliment>();
            Units = new HashSet<Unit>();
        }

        public int Id { get; set; }
        public decimal SaleId { get; set; }
        public string InvoiceCode { get; set; }
        public decimal ItemId { get; set; }
        public string ItemCatogery { get; set; }
        public string ItemName { get; set; }
        public decimal Quentity { get; set; }
        public decimal UnitId { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }

        public virtual ICollection<Catogery> Catogeries { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Suppliment> Suppliments { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
