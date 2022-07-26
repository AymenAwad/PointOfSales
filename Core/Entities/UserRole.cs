using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
   public class UserRole 
    {
        public  Role Role { get; set; }
        public  Userlogin User { get; set; }
    }
}
