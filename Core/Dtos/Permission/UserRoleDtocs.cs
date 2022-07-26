using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Permission
{
    public class UserRoleDtocs
    {
        public int? Id { get; set; }
        public decimal UserId { get; set; }
        public decimal RoleId { get; set; }

        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
