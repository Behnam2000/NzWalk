using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();

            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();

            // Alternative (Strongly-typed / Recommended in EF Core):
            // Instead of using strings (which won't catch typos at compile time), you can use lambda expressions:
            // |  return await dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).ToListAsync();  | 
        }
    }
}
