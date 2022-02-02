using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TikoTask.Business.Abstract;
using TikoTask.Data.Entities;

namespace TikoTask.API.Controllers
{   //This class fulfill the operations for House Entity
    [ApiController]
    [Route("[controller]")]
    public class TikoHouseController : ControllerBase
    {
        private readonly ITikoRepository _tikoRepository;
        public TikoHouseController(ITikoRepository tikoRepository)
        {
            _tikoRepository = tikoRepository;
        }

        /// <summary>
        /// Creating House via Entity, All Necessary except Description
        /// </summary>
        /// <returns></returns>
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
        
        /// <summary>
        /// Deleting House by Id
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteHouse(int id)
        {
            await _tikoRepository.DeleteHouse(id);
            return Ok();
        }

        /// <summary>
        /// Listing Houses via Agent Name
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetHousesByAgent(string agent)
        {
            var houses = await _tikoRepository.GetHousesbyAgent(agent);
            if (!houses.Any())
            {
                return NotFound();
            }
            return Ok(houses);
        }

        /// <summary>
        /// Listing Houses via City Name
        /// </summary>
        /// <returns></returns>
        [HttpGet("{city}")]
        public async Task<ActionResult<IEnumerable<House>>> GetHousesByCities(string city)
        {
            var houses = await _tikoRepository.GetHousesbyCity(city);
            if (!houses.Any())
            {
                return NotFound();
            }
            return Ok(houses);
        }

        /// <summary>
        /// Updating House Price by It's Id
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHousePrice(int id, string price)
        {
            await _tikoRepository.UpdateHousePrice(id, price);
            return Ok();
        }
    }
}
