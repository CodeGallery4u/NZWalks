using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZWalks.API.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NzWalksDbContext _dbContext;

        public WalkDifficultyRepository(NzWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Models.WalkDifficulty>> GetAll()
        {
            return await _dbContext.walkDifficulties.ToListAsync();
        }
    }
}
