using NZWalks.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> Getll();
        Task<Walk?> GetByIdAsync(Guid id);
        Task<Walk> AddAsync(Walk walk);
        Task<Walk?> UpdateAsync(Guid id, Walk walk);

        Task<Walk?> DeleteAsync(Guid id);
    }
}
