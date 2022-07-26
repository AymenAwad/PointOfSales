using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class Vaucher
    {
        public Vaucher()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string VaucherCode { get; set; }
        public decimal Amount { get; set; }
        public string FeesType { get; set; }
        public decimal FeesAmount { get; set; }
        public string FromAccount { get; set; }
        public string ToAccount { get; set; }
        public string Notes { get; set; }
        public decimal? CreatedBy { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }

        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
