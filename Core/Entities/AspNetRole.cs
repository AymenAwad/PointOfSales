using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class AspNetRole : IdentityRole<int>
    {
        public AspNetRole()
        {
        
            AspNetUserRoles = new HashSet<AspNetUserRole>();
        }

       
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
    }
}
