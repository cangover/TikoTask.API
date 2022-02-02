using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TikoTask.Business.Abstract;
using TikoTask.Data.Entities;

namespace TikoTask.API.Controllers
{   //This class fulfill the operations for City Entity
    [ApiController]
    [Route("[controller]")]
    public class TikoCityController : ControllerBase
    {
        private readonly ITikoRepository _tikoRepository;
        public TikoCityController(ITikoRepository tikoRepository)
        {
            _tikoRepository = tikoRepository;
        }

        /// <summary>
        /// Creating City via Entity
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CreateCity(City city)
        {
            City newCity = new()
            {
                Name = city.Name
            };
            await _tikoRepository.CreateCity(newCity);
            return Ok();
        }

        /// <summary>
        /// Get All Cities
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var cities = await _tikoRepository.GetCities();
            return Ok(cities);
        }


    }
}
