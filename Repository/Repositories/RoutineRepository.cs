using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Context;

namespace Repository.Repositories
{
    public class RoutineRepository(ApplicationDbContext context)
    {
        public async Task<List<Routine>> GetRoutinesAsync()
        {
            return await context.Routines.ToListAsync();
        }
    }
}
