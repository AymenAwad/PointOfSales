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

namespace PointOfSellManagementSystem.Controllers.UserLogin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgent _agent;
        private readonly IMapper _mapper;

        public AgentController(IAgent agent, IMapper mapper)
        {
            _agent = agent;
            _mapper = mapper;
        }

        [HttpGet("Agents")]
        public async Task<IActionResult> Agents()
        {
            var AgentOfAgent = await _agent.GetAll();
            return Ok(AgentOfAgent);
        }
        [HttpGet("AgentsById")]
        public async Task<IActionResult> GetAgentById(decimal Id)
        {
            var SingleAgent= await _agent.GetById(Id);
            //Check if variable is null or not
            if (SingleAgent != null)
                return Ok(SingleAgent);

            return BadRequest("Agent Not Found");

        }

        [HttpPost("CreateAgent")]
        public async Task<IActionResult> CreateAddress(AgentDto agentDto)
        {
            try
            {
                //Map from Dto to Entity
                var AgentToCreate = _mapper.Map<Agent>(agentDto);

                //assinge defulat data
                AgentToCreate.Status = "Active";
                AgentToCreate.Lastupdated = DateTime.Now;
                _agent.Add(AgentToCreate);
                await _agent.SaveChanges();
                return Ok("Agent Created Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("DeleteAgent")]
        public async Task<IActionResult> Delete(decimal Id)
        {
            var exitsAgent = await _agent.GetById(Id);
            //check if Address exit or not 
            if (exitsAgent != null)
            {
                _agent.Remove(exitsAgent);
                //save changes
                await _agent.SaveChanges();
                return Ok("Agent Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("UpdateStatusDeleted")]
        public async Task<IActionResult> Update(decimal Id)
        {
            //Get Address From Database
            var dbAgent = await _agent.GetById(Id);

            //Update Address Status to Deleted
            dbAgent.Status = "Deleted";

            //Save Changes
            await _agent.SaveChanges();

            return Ok("Agent Updated Successfully ");
        }

        [HttpPut("UpdateAgent")]
        public async Task<IActionResult> UpdateAgent(decimal Id, AgentDto agentDto)
        {
            //Get Address From Database
            var dbAgent = await _agent.GetById(Id);
            //Update Address Detials
           
            dbAgent.Name = agentDto.Name;
            dbAgent.SaleId = agentDto.SaleId;
            dbAgent.Description = agentDto.Description;
            dbAgent.Email = agentDto.Email;
            dbAgent.Type = agentDto.Type;
            dbAgent.Location = agentDto.Location;
            dbAgent.Lastupdated = DateTime.Now;
            //Save Changes
            await _agent.SaveChanges();

            return Ok("Agent Updated Successfully ");
        }

    }
}
