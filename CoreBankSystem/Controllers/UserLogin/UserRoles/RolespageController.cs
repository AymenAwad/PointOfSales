using AutoMapper;
using Core;
using Core.Dtos.UserLoginDto.UserRoles;
using Core.Interfaces.UserLogin.UserRoles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.UserLogin.UserRoles
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolespageController : ControllerBase
    {
        private readonly IRolespage _rolespage;
        private readonly IMapper _mapper;

        public RolespageController(IRolespage rolespage , IMapper mapper)
        {
            _rolespage = rolespage;
            _mapper = mapper;
        }

        // GET: api/<UserRolesController>
        [HttpGet("GetRolespageDetails")]
        public async Task<IActionResult> Get()
        {
            var _reslut = await _rolespage.GetAll();
            return Ok(_reslut);
        }

        // GET api/<UserRolesController>/5
        [HttpGet("GetRolespageByid")]
        public async Task<IActionResult> GetRolespageByID(decimal id)
        {
            var _reslut = await _rolespage.GetById(id);
            if (_reslut != null)
                return Ok(_reslut);

            return BadRequest("Rolespage Not Found");

        }

        // POST api/<UserRolesController>
        [HttpPost("CreateRolespage")]
        public async Task<IActionResult> CreateRolespage(RolePageDto rolespageDto)
        {

            try
            {
                var id = _rolespage.MaxId();

                var PageToCreate = _mapper.Map<Rolespage>(rolespageDto);

                PageToCreate.Rolespagesid = (short)id;

                _rolespage.Add(PageToCreate);

                await _rolespage.SaveChanges();

                return Ok("Rolespage Created Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<UserRolesController>/5
        [HttpPut("UpdateRolespage")]
        public async Task<IActionResult> UpdateRolespage(short Id, Rolespage rolespageDto)
        {
            var dbRolespage = await _rolespage.GetById(Id);


            dbRolespage.Roleid = rolespageDto.Roleid;
            dbRolespage.Pageid = rolespageDto.Pageid;

            await _rolespage.SaveChanges();

            return Ok("Rolespage Updated Successfully ");
        }

        // DELETE api/<UserRolesController>/5
        [HttpDelete("DeleteRolespage")]
        public async Task<IActionResult> DeleteRolespage(short id)
        {
            var exitsRolespage = await _rolespage.GetById(id);

            if (exitsRolespage != null)
            {
                _rolespage.Remove(exitsRolespage);

                //save changes
                await _rolespage.SaveChanges();

                return Ok("Rolespage Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }

    }
}
