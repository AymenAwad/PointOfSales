using AutoMapper;
using Core.Dtos.Settings;
using Core.Entities;
using Core.Interfaces.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSellManagementSystem.Controllers.Setting
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchGallaryController : ControllerBase
    {
        private readonly IBranch_Gallary _branch_Gallary;
        private readonly IMapper _mapper;

        public BranchGallaryController(IBranch_Gallary branch_Gallary ,IMapper mapper)
        {
            _branch_Gallary = branch_Gallary;
            _mapper = mapper;
        }

        [HttpGet("BranchGallaries")]
        public async Task<IActionResult> BranchGallaries()
        {
            var branchGallary = await _branch_Gallary.GetAll();
            return Ok(branchGallary);
        }
        [HttpGet("BranchGallaryById")]
        public async Task<IActionResult> GetBranchGallaryById(decimal Id)
        {
            var SingleBranchGallary = await _branch_Gallary.GetById(Id);
            //Check if variable is null or not
            if (SingleBranchGallary != null)
                return Ok(SingleBranchGallary);

            return BadRequest("BranchGallary Not Found");

        }

        [HttpPost("CreateBranchGallary")]
        public async Task<IActionResult> CreateBranchGallary(BranchGallaryDto branchGallaryDto)
        {
            try
            {
                //Map from Dto to Entity
                var BranchGallaryToCreate = _mapper.Map<BranchGallary>(branchGallaryDto);

                //assinge defulat data
                BranchGallaryToCreate.Status = "Active";
                BranchGallaryToCreate.Lastupdated = DateTime.Now;
                _branch_Gallary.Add(BranchGallaryToCreate);
                await _branch_Gallary.SaveChanges();
                return Ok("BranchGallary Created Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("DeleteBranchGallary")]
        public async Task<IActionResult> DeleteBranchGallary(decimal Id)
        {
            var exitsBranchGallary = await _branch_Gallary.GetById(Id);
            //check if BranchGallary exit or not 
            if (exitsBranchGallary != null)
            {
                _branch_Gallary.Remove(exitsBranchGallary);
                //save changes
                await _branch_Gallary.SaveChanges();
                return Ok("BranchGallary Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("UpdateStatusDeleted")]
        public async Task<IActionResult> Update(decimal Id)
        {
            //Get BranchGallary From Database
            var dbBranchGallary = await _branch_Gallary.GetById(Id);

            //Update BranchGallary Status to Deleted
            dbBranchGallary.Status = "Deleted";

            //Save Changes
            await _branch_Gallary.SaveChanges();

            return Ok("BranchGallary Updated Successfully ");
        }

        [HttpPut("UpdateBranchGallary")]
        public async Task<IActionResult> UpdateBranchGallary(decimal Id, BranchGallaryDto branchGallaryDto)
        {
            //Get BranchGallary From Database
            var dbBranchGallary = await _branch_Gallary.GetById(Id);
            //Update BranchGallary Detials

            dbBranchGallary.Name = branchGallaryDto.Name;
            dbBranchGallary.SaleId = branchGallaryDto.SaleId;
            dbBranchGallary.Description = branchGallaryDto.Description;
            dbBranchGallary.StoreId = branchGallaryDto.StoreId;
            dbBranchGallary.Type = branchGallaryDto.Type;
            dbBranchGallary.Location = branchGallaryDto.Location;
            dbBranchGallary.SupplimentId = branchGallaryDto.SupplimentId;
            dbBranchGallary.Price = branchGallaryDto.Price;
            dbBranchGallary.Lastupdated = DateTime.Now;
            //Save Changes
            await _branch_Gallary.SaveChanges();

            return Ok("BranchGallary Updated Successfully ");
        }

    }
}
