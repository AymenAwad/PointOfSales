using AutoMapper;
using Core;
using Core.Dtos.UserLoginDto.UserRoles;
using Core.Interfaces.UserLogin.UserRoles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.UserLogin.UserRoles
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IPage _page;
        private readonly IMapper _mapper;

        public PageController(IPage page , IMapper mapper)
        {
            _page = page;
            _mapper = mapper;
        }

        // GET: api/<UserRolesController>
        [HttpGet("GetPagesDetails")]
        public async Task<IActionResult> Get()
        {
            var _reslut = await _page.GetAll();
            return Ok(_reslut);
        }

        // GET api/<UserRolesController>/5
        [HttpGet("GetPageByid")]
        public async Task<IActionResult> GetPageByID(decimal id)
        {
            var _reslut = await _page.GetById(id);
            if (_reslut != null)
                return Ok(_reslut);

            return BadRequest("Page Not Found");

        }

        // POST api/<UserRolesController>
        [HttpPost("CreatePage")]
        public async Task<IActionResult> CreatePage(PageDto pageDto)
        {

            try
            {
                var id = _page.MaxId();

                var PageToCreate = _mapper.Map<Page>(pageDto);

                PageToCreate.Pageid = (short)id;

                _page.Add(PageToCreate);

                await _page.SaveChanges();

                return Ok("Page Created Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<UserRolesController>/5
        [HttpPut("UpdatePage")]
        public async Task<IActionResult> UpdatePage(short Id, PageDto pageDto)
        {
            var dbPage = await _page.GetById(Id);


            dbPage.Action = pageDto.Action;
            dbPage.Actionfoerign = pageDto.Actionfoerign;
            dbPage.Area = pageDto.Area;
            dbPage.Controller = pageDto.Controller;
            dbPage.Controllerfoering = pageDto.Controllerfoering;
            dbPage.Name = pageDto.Name;


            await _page.SaveChanges();

            return Ok("Page Updated Successfully ");
        }

        // DELETE api/<UserRolesController>/5
        [HttpDelete("DeletePage")]
        public async Task<IActionResult> DeletePage(short id)
        {
            var exitsPage = await _page.GetById(id);

            if (exitsPage != null)
            {
                _page.Remove(exitsPage);

                //save changes
                await _page.SaveChanges();

                return Ok("Page Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
