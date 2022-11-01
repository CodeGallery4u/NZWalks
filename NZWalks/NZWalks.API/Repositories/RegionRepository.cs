using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NzWalksDbContext _dbContext;

        public RegionRepository(NzWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            await _dbContext.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var region = await _dbContext.Regions.FirstOrDefaultAsync(a => a.Id == id);
            if (region == null) return null;

            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();

            return region;

        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionAsync(Guid id)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(a => a.Id == id);
            if (existingRegion == null) return null;
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;

            await _dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
