using Application.Repository.BaseService;
using Core.Entities;
using Core.Interfaces.Permission;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.UserLogin.Permission
{
    public class UserRoleRepository : BaseServiceRepository<AspNetUserRole> , IUserRole
    {
        private readonly ApplicationDbContext _context;

        public UserRoleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
