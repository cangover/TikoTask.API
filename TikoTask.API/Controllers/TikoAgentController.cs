using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TikoTask.Business.Abstract;
using TikoTask.Data.Entities;

namespace TikoTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TikoAgentController : ControllerBase
    {
        private readonly ITikoRepository _tikoRepository;
        public TikoAgentController(ITikoRepository tikoRepository)
        {
            _tikoRepository = tikoRepository;
        }

        /// <summary>
        /// Creating Agent via Entity
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateAgent(Agent agent)
        {
            Agent newAgent = new()
            {
                Id = agent.Id,
                Name = agent.Name,
                City = agent.City
            };
            await _tikoRepository.CreateAgent(newAgent);
            return Ok();
        }

        /// <summary>
        /// Deleting Agent by Id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAgent(int id)
        {
            await _tikoRepository.DeleteAgent(id);
            if (id == null)
            {
                return NotFound();
            }
            return Ok();
        }

        /// <summary>
        /// Get All Agents
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAgents()
        {
            var cities = await _tikoRepository.GetAgents();
            return Ok(cities);
        }
    }
}
