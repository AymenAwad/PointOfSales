using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class Story
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }
        public int? StoreQuantitiesId { get; set; }
        public int? StoreReturnedId { get; set; }
        public int? BranchGallaryId { get; set; }

        public virtual BranchGallary BranchGallary { get; set; }
        public virtual StoreQuantity StoreQuantities { get; set; }
        public virtual StoreReturned StoreReturned { get; set; }
    }
}
