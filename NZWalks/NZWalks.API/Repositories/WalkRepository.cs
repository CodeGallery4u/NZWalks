using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NzWalksDbContext _dbContext;

        public WalkRepository(NzWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            //Get db record
            var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(a => a.Id == id);
            //Null check
            if (existingWalk == null) return null;
            //delete record
            _dbContext.Walks.Remove(existingWalk);
            await _dbContext.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Walks.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Walk>> GetAll()
        {
            return await _dbContext.Walks.ToListAsync();
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            //Get DB record
            var existingWalk = await _dbContext.Walks.FirstOrDefaultAsync(a => a.Id == id);
            if (existingWalk == null) return null;
            //
            existingWalk.Name = walk.Name;
            existingWalk.region = walk.region;
            existingWalk.Length = walk.Length;

            await _dbContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
