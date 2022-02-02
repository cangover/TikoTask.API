using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TikoTask.Data.Entities;

namespace TikoTask.Data.Context
{
    public interface ITikoDBContext
    {
        DbSet<City> Cities { get; set; }
        DbSet<Agent> Agents { get; set; }
        DbSet<House> Houses { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
