using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class Sattelment
    {
        public Sattelment()
        {
            Sales = new HashSet<Sale>();
            Suppliments = new HashSet<Suppliment>();
        }

        public int Id { get; set; }
        public string InvoiceCode { get; set; }
        public string FromAccount { get; set; }
        public int FromName { get; set; }
        public string ToAccount { get; set; }
        public int ToName { get; set; }
        public string SalerName { get; set; }
        public string AccountNo { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountStill { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Suppliment> Suppliments { get; set; }
    }
}
