using AutoMapper;
using Core;
using Core.Dtos.UserLoginDto.UserRoles;
using Core.Interfaces.UserLogin.UserRoles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers.UserLogin.UserRoles
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IRoles _repo;
        private readonly IMapper _mapper;

        public UserRolesController(IRoles repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/<UserRolesController>
        [HttpGet("GetRolesDetails")]
        public async Task<IActionResult> Get()
        {
            var _reslut = await _repo.GetAll();
            return Ok (_reslut);
        }

        // GET api/<UserRolesController>/5
        [HttpGet("GetRolesByid")]
        public async Task<IActionResult> GetRolesByID(decimal id)
        {
            var _reslut = await _repo.GetById(id);
            if (_reslut != null)
                return Ok(_reslut);

            return BadRequest("Roles Not Found");

        }

        // POST api/<UserRolesController>
        //[HttpPost("CreateRole")]
        //public async Task<IActionResult> CreateRole(RolesDto rolesDto)
        //{
            
        //    try
        //    {
        //        var id = _repo.MaxId();

        //        var RolesToCreate = _mapper.Map<Role>(rolesDto);

        //        RolesToCreate.Roleid = (short)id;

        //        _repo.Add(RolesToCreate);

        //        await _repo.SaveChanges();

        //        return Ok("Role Created Successfully");
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        // DELETE api/<UserRolesController>/5
        [HttpDelete("DeleteRole")]
        public async Task<IActionResult> DeleteRole(short id)
        {
            var exitsRole = await _repo.GetById(id);

            if (exitsRole != null)
            {
                _repo.Remove(exitsRole);

                //save changes
                await _repo.SaveChanges();

                return Ok("Role Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        // PUT api/<UserRolesController>/5
        [HttpPut("UpdateRoles")]
        public async Task<IActionResult> UpdateRoles(short Id, RolesDto rolesDto)
        {
            var dbRole = await _repo.GetById(Id);


            dbRole.Name = rolesDto.NAME;

            await _repo.SaveChanges();

            return Ok("Role Updated Successfully ");
        }
    }
}
