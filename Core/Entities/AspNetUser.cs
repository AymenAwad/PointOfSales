using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class AspNetUser : IdentityUser<int>
    {
        public AspNetUser()
        {
          
       
            AspNetUserRoles = new HashSet<AspNetUserRole>();
        }

       
        public string Userpassword { get; set; }
        public string Nameen { get; set; }
        public DateTime Creationdate { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }
        public decimal? LastupdatedBy { get; set; }
        public int? CreatedBy { get; set; }
        public int? ItemId { get; set; }
        public int? StoreQuantitiesId { get; set; }
        public int? StoreReturnedId { get; set; }
        public int? VauchersId { get; set; }
        public int? SaleId { get; set; }
        public int? SupplimentId { get; set; }
        

        public virtual Item Item { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual StoreQuantity StoreQuantities { get; set; }
        public virtual StoreReturned StoreReturned { get; set; }
        public virtual Suppliment Suppliment { get; set; }
        public virtual Vaucher Vauchers { get; set; }
     
      
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
      
    }
}
