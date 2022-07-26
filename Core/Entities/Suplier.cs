using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class Suplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }
        public int? SupplimentId { get; set; }

        public virtual Suppliment Suppliment { get; set; }
    }
}
