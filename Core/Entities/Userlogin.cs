using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public class Userlogin 
    {

        //public decimal Id { get; set; }
        //public string UserName { get; set; }
        public string Userpassword { get; set; }
        public string Nameen { get; set; }
        public DateTime Creationdate { get; set; }
        public string Status { get; set; }
        public DateTime Lastupdated { get; set; }
        public decimal? LastupdatedBy { get; set; }
        public decimal? CreatedBy { get; set; }
        //public byte[] Passwordsalt { get; set; }
        //public byte[] Passwordhash { get; set; }
      
       
        public ICollection<AspNetUserRole> AspNetUserRoles { get; set; }

        public Item Item { get; set; }
        public StoreQuantity StoreQuantity { get; set; }
        public StoreReturned StoreReturned { get; set; }
        public Vaucher Vaucher { get; set; }
        public Sale Sale { get; set; }
        public Suppliment Suppliment { get; set; }
    }
}
