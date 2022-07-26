using Core.Dtos.UserLoginDto;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces.BaseService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.UserLogin
{
   public interface IUserlogin : IBaseService<AspNetUser>
    {
        Task<AspNetUser> Register(AspNetUser user, string Password);
        Task<AspNetUser> Login(decimal UserId,string UserName, string Password);
        Task<bool> UserExits(string UserName);
        Task<IEnumerable <UserForDetailsDto>> UserDetails(decimal Id , string Name);
       
    }
}
