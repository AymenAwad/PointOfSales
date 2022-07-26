using AutoMapper;
using Core;
using Core.Dtos.Permission;
using Core.Entities;
using Core.Interfaces.Permission;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.Permission
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRole _userRole;
        private readonly IMapper _mapper;

        public UserRoleController(IUserRole userRole, IMapper mapper)
        {
            _userRole = userRole;
            _mapper = mapper;
        }
        [HttpGet("UserRoleDetails")]
        public async Task<IActionResult> RoleDetails()
        {
            var ListOfRoles = await _userRole.GetAll();
    
            return Ok(ListOfRoles);
        }

        [HttpGet("GetUserRoleById")]
        public async Task<IActionResult> GetRoleById(decimal Id)
        {
            var SingleUserRole = await _userRole.GetById(Id);

            //Check if variable is null or not
            if (SingleUserRole != null)
                return Ok(SingleUserRole);

            return BadRequest("UserRole Not Found");

        }

        [HttpPost("CreateUserRole")]
        public async Task<IActionResult> CreateUserRole(UserRoleDtocs roleDto)
       {
            try
            {

                var UnitToCreate = _mapper.Map<AspNetUserRole>(roleDto);
               
                _userRole.Add(UnitToCreate);

                await _userRole.SaveChanges();
                return Ok("UserRole Created Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
