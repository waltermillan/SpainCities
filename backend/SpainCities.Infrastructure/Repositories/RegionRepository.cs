using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure.Repositories;
public class RegionRepository(SpainCitiesContext context) : GenericRepository<Region>(context), IRegionRepository
{
    public async Task<Region> GetByRegionIdAsync(int regionId)
    {
        return await _context.Regions
                             .FirstOrDefaultAsync(a => a.Id == regionId);
    }

    public override async Task<Region> GetByIdAsync(int id)
    {
        return await _context.Regions
                          .FirstOrDefaultAsync(p => p.Id == id);

    }

    public override async Task<IEnumerable<Region>> GetAllAsync()
    {
        return await _context.Regions
                            .ToListAsync();
    }
}
