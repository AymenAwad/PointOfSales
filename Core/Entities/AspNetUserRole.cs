using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public partial class AspNetUserRole : IdentityUserRole<int>
    {
        public int Id { get; set; }

        public virtual AspNetRole Role { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
