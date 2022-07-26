
using Application.Commons.EmailConfigurations;
using AutoMapper;
using Core;
using Core.Dtos.UserLoginDto;
using Core.Entities;
using Core.Helpers;
using Core.Interfaces.UserLogin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Controllers.UserLogin
{
   
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
     
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IUserlogin _repo;
        private readonly UserManager<AspNetUser> _userManager;
        private readonly SignInManager<AspNetUser> _signInManager;

        public UserLoginController(IUserlogin repo, IConfiguration config,UserManager<AspNetUser> userManager ,SignInManager<AspNetUser> signInManager,
        IMapper mapper, IEmailSender emailSender)
        {
            _repo = repo;
            _config = config;
            _mapper = mapper;
            _emailSender = emailSender;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //[HttpGet("UsersPagenation")]
        //public async Task<IActionResult> GetUsers([FromQuery] PaginationParams paginationParams)
        //{
        //    var users = await _repo.GetUserPagedList(paginationParams);
        //    var result = new
        //    {
        //        users = users,
        //        currentPage = users.CurrentPage,
        //        pageSize = users.PageSize,
        //        totalCount = users.TotalCount,
        //        totalPages = users.TotalPages

        //    };
        //    return Ok(result);
        //}

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _repo.GetAll();
            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);
            return Ok(usersToReturn);
        }
      
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExits(userForRegisterDto.Username))
            {
                return BadRequest("this user is already register");
            }

            var userToCreate = _mapper.Map<AspNetUser>(userForRegisterDto);
            userToCreate.Status = "Active";
            userToCreate.Lastupdated = DateTime.Now;
            userToCreate.Creationdate = DateTime.Now;
            var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Userpassword);
            var userToReturn = _mapper.Map<UserForDetailsDto>(userToCreate);
            if (result.Succeeded)
            {
                return Ok(userToReturn);
            }
            return BadRequest(result.Errors);
        }

        [HttpGet("GetUserName")]
        public async Task<IActionResult> GetUserName(decimal Id)
        {
  
            var UserName = await _repo.GetById(Id);
            if(UserName != null)
            
                return Ok(UserName.UserName);
            
            return BadRequest("UserName is not found");

        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> UserDetails(decimal Id ,string Name)
        {
            var singleUser = await _repo.UserDetails(Id , Name);

            //Check if variable is null or not
            if (singleUser != null)
                return Ok(singleUser);

            return BadRequest("User Not Found");
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] UserForLoginDto userloginnDto)
        //{
        //    var user = await _userManager.FindByNameAsync(userloginnDto.UserName);
        //    var result = await _signInManager.CheckPasswordSignInAsync(user, userloginnDto.Password, false);

        //    if (result.Succeeded)
        //    {
        //        //var AppUser = _userManager.Users
        //        //    .FirstOrDefault(u => u.NormalizedUserName == userloginnDto.UserName.ToUpper());
        //        return Ok(new
        //        {
        //            Token = GenerateJwtTokem(AppUser).Result
        //        });
        //    }
        //    return Unauthorized();

        //}
        //private async Task<string> GenerateJwtTokem(Userlogin userlogin)
        //{
        //    var claims = new List<Claim>
        //  {
        //     new Claim(ClaimTypes.Name,userlogin.UserName.ToString()),
        //    new Claim(ClaimTypes.SerialNumber,userlogin.Nameen.ToString()),
        //    new Claim(ClaimTypes.Surname,userlogin.Healthunitid.ToString()),
        //    new Claim(ClaimTypes.NameIdentifier,userlogin.Id.ToString()),
        //      new Claim(JwtRegisteredClaimNames.UniqueName,userlogin.UserName.ToString()),

        //     };
        //    var roles = await _userManager.GetRolesAsync(userlogin);
        //    foreach (var role in roles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role));
        //    }
            
        //    var key = new SymmetricSecurityKey(Encoding.UTF8
        //              .GetBytes(_config.GetSection("AppSettings:Token").Value));
        //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        //    var TokenDesc = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(claims),
        //        Expires = System.DateTime.Now.AddDays(1),
        //        SigningCredentials = creds
        //    };
        //    var TokenHandler = new JwtSecurityTokenHandler();
        //    var Token = TokenHandler.CreateToken(TokenDesc);
        //    return TokenHandler.WriteToken(Token);
        //}

        [HttpPut("UpdatUser")]
        public async Task<IActionResult> UpdatUser(decimal Id, UserForListDto userDto)
        {
            //Get State From Database
            var dbUser = await _repo.GetById(Id);
            if (dbUser == null)
                return BadRequest("User Not Found");
            //Update State Details
            dbUser.Status = userDto.Status;
            dbUser.Nameen = userDto.Nameen;
         
            dbUser.Lastupdated = DateTime.Now;

            //Save Changes
            await _repo.SaveChanges();

            return Ok("User Updated Successfully ");
        }

        [HttpPut("UpdateUserDeleted")]
        public async Task<IActionResult> UpdateUserDeleted([FromQuery] decimal id)
        {
            //Get User From Database
            var dbUser = await _repo.GetById(id);

            if (dbUser == null)
                return BadRequest("User Not Found");
            //Update User Status to Deleted
            dbUser.Status = "Deleted";

            //Save Changes
            await _repo.SaveChanges();

            return Ok("User Updated Successfully ");
        }
    }
}
