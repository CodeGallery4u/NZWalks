using NZWalks.API.Models;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAll();
        Task<Region?> GetRegionAsync(Guid id);
        Task<Region> AddRegionAsync(Region region);
        Task<Region?> DeleteRegionAsync(Guid id);
        Task<Region?> UpdateAsync(Guid id, Region region); 
    }
}
