using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
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

        public async Task<IEnumerable<House>> GetHousesbyAgent(string agent)
        {
            return await _context.Houses.Where(x => x.Agent == agent).ToListAsync();
        }

        public async Task<IEnumerable<House>> GetHousesbyCity(string city)
        {
            return await _context.Houses.Where(x => x.City == city).ToListAsync();
        }

        public async Task UpdateHousePrice(int id, string price)
        {
            bool has_item = false;
            foreach (var e in _context.Houses.Where(a => a.Id == id))
            {
                e.Price = price;
                has_item = true;
            }
            if (has_item == false)
            {
                throw new NullReferenceException();
            }
            await _context.SaveChangesAsync();
        }
    }
}
