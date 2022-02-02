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
    public class TikoController : ControllerBase
    {
        private readonly ITikoRepository _tikoRepository;
        public TikoController(ITikoRepository tikoRepository)
        {
            _tikoRepository = tikoRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAgent(Agent agent)
        {
            Agent newAgent = new()
            {
                Name = agent.Name,
                Id = agent.Id
            };
            await _tikoRepository.CreateAgent(newAgent);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateCity(City city)
        {
            City newCity = new()
            {
                Name =city.Name
            };
            await _tikoRepository.CreateCity(newCity);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateHouse(House house)
        {
            House newHouse = new()
            {
                Id = house.Id,
                City = house.City,
                Agent = house.Agent,
                Price = house.Price,
                Address = house.Address,
                BedroomCount = house.BedroomCount
            };
            await _tikoRepository.CreateHouse(newHouse);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAgent(int id)
        {
            await _tikoRepository.DeleteAgent(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHouse(int id)
        {
            await _tikoRepository.DeleteHouse(id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var cities = await _tikoRepository.GetCities();
            return Ok(cities);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agent>>> GetAgents()
        {
            var cities = await _tikoRepository.GetAgents();
            return Ok(cities);
        }

        [HttpGet]
        public async Task<ActionResult<House>> GetHousesByAgent(Agent name)
        {
            var houseByAgent = await _tikoRepository.GetHousesbyAgent(name);
            if(houseByAgent == null)
            {
                return NotFound();
            }
            return Ok(houseByAgent);
        }

        [HttpGet]
        public async Task<ActionResult<House>> GetHousesByCities(City name)
        {
            var houseByCity = await _tikoRepository.GetHousesbyCity(name);
            if (houseByCity == null)
            {
                return NotFound();
            }
            return Ok(houseByCity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHousePrice(House house)
        {
            House newPrice = new()
            {
                Price = house.Price
            };
            await _tikoRepository.UpdateHousePrice(newPrice);
            return Ok();
        }
    }
}
