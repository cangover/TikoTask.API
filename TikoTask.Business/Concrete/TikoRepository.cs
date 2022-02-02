using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikoTask.Business.Abstract;
using TikoTask.Data.Context;
using TikoTask.Data.Entities;

namespace TikoTask.Business.Concrete
{
    public class TikoRepository : ITikoRepository
    {
        private readonly ITikoDBContext _context;
        public TikoRepository(ITikoDBContext context)
        {
            _context = context;
        }
        public async Task CreateAgent(Agent agent)
        {
            _context.Agents.Add(agent);
            await _context.SaveChangesAsync();
        }

        public async Task CreateCity(City city)
        {
            _context.Cities.Add(city);
            await _context.SaveChangesAsync();
        }

        public async Task CreateHouse(House house)
        {
            _context.Houses.Add(house);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAgent(int id)
        {
            var item = await _context.Agents.FindAsync(id);
            if(item == null){
                throw new NullReferenceException();
            }
            _context.Agents.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteHouse(int id)
        {
            var item = await _context.Houses.FindAsync(id);
            if (item == null)
            {
                throw new NullReferenceException();
            }
            _context.Houses.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Agent>> GetAgents()
        {
            return await _context.Agents.ToListAsync();
        }

        public async Task<IEnumerable<City>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<House> GetHousesbyAgent(Agent name)
        {
            return await _context.Houses.FindAsync(name);
        }

        public async Task<House> GetHousesbyCity(City name)
        {
            return await _context.Houses.FindAsync(name);
        }

        public async Task UpdateHousePrice(House house)
        {
            var item = await _context.Houses.FindAsync(house.Id);
            if (item == null)
            {
                throw new NullReferenceException();
            }
            item.Price = house.Price;
            await _context.SaveChangesAsync();
        }
    }
}
