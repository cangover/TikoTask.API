using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TikoTask.Data.Context;
using TikoTask.Data.Entities;

namespace TikoTask.Data.Context
{
    public class TikoDBContext : DbContext, ITikoDBContext
    {
        public TikoDBContext(DbContextOptions<TikoDBContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<House> Houses { get; set; }

        
    }
}
