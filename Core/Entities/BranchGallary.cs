using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class BranchGallary
    {
        public BranchGallary()
        {
            Stories = new HashSet<Story>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int StoreId { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }
        public int? SaleId { get; set; }
        public int? SupplimentId { get; set; }

        public virtual Sale Sale { get; set; }
        public virtual Suppliment Suppliment { get; set; }
        public virtual ICollection<Story> Stories { get; set; }
    }
}
