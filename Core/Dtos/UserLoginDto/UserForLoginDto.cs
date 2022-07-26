using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.UserLoginDto
{
    public class UserForLoginDto
    {
        public decimal Id { get; set; }
       public string UserName { get; set; }
        public string Password { get; set; }
    }
}
