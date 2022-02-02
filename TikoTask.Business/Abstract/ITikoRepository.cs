using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikoTask.Data.Entities;

namespace TikoTask.Business.Abstract
{
    public interface ITikoRepository
    {
        Task<IEnumerable<City>> GetCities();
        Task CreateCity(City city);
        Task<IEnumerable<Agent>> GetAgents();
        Task CreateAgent(Agent agent);
        Task DeleteAgent(int id);
        Task<House> GetHousesbyAgent(Agent name);
        Task<House> GetHousesbyCity(City name);
        Task CreateHouse(House house);
        Task UpdateHousePrice(House house);
        Task DeleteHouse(int id);
    }
}
