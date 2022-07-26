using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class Suppliment
    {
        public Suppliment()
        {
            AspNetUsers = new HashSet<AspNetUser>();
            BranchGallaries = new HashSet<BranchGallary>();
            Supliers = new HashSet<Suplier>();
        }

        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAccount { get; set; }
        public int SupplierId { get; set; }
        public string PayType { get; set; }
        public string Type { get; set; }
        public int BranchId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Total { get; set; }
        public decimal? CreatedBy { get; set; }
        public string InvoiceCode { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }
        public int? SalesInformationId { get; set; }
        public int? SupplimentInformationId { get; set; }
        public int? SattelmentId { get; set; }

        public virtual SalesInformation SalesInformation { get; set; }
        public virtual Sattelment Sattelment { get; set; }
        public virtual SupplimentInformation SupplimentInformation { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        public virtual ICollection<BranchGallary> BranchGallaries { get; set; }
        public virtual ICollection<Suplier> Supliers { get; set; }
    }
}
