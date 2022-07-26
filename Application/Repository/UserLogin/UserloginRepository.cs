using Application.Repository.BaseService;
using Core;
using Core.Helpers;
using Core.Interfaces.UserLogin;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Core.Dtos.UserLoginDto;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Core.Entities;

namespace Application.Repository.UserLogin
{
    public class UserloginRepository : BaseServiceRepository<AspNetUser>, IUserlogin
    {

        private readonly ApplicationDbContext _context;

        public UserloginRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AspNetUser> Login(decimal UserId, string UserName, string Password)
        {
            var user = await _context.AspNetUsers.FirstOrDefaultAsync(x => x.Id == UserId);
            if (user == null)
                return null;
            return user;
        }

        public async Task<AspNetUser> Register(AspNetUser user, string Password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(Password, out passwordHash, out passwordSalt);
            await _context.AspNetUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExits(string UserName)
        {
            if (await _context.AspNetUsers.AnyAsync(x => x.UserName == UserName))
                return true;
            return false;
        }



        public async Task<IEnumerable<UserForDetailsDto>> UserDetails(decimal Id, string Name)
        {
            var user = _context.AspNetUsers
                           .Where(p => p.Id == Id)
                           .Select(p => new UserForDetailsDto()
                           {
                               Id = p.Id,
                               //Name = p.UserName,
                               //Nameen = p.Nameen,
                               //Status = p.Status,
                               //Sectionid = p.Sectionid,
                               //SectionName = p.Section.Name,
                               //SectionNameen = p.Section.Nameen,
                               //Depatmentid = p.Depatmentid,
                               //DepartmentName = p.Depatment.Name,
                               //DepartmentNameen = p.Depatment.Nameen,
                               //Unitid = p.Unitid,
                               //UnitName = p.Unit.Name,
                               //UnitNameen = p.Unit.Nameen,
                               //Healthunitid = p.Healthunitid

                           });
            return user;
        }
    }
}
