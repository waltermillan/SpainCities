using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProvinceRepository(SpainCitiesContext context) : GenericRepository<Province>(context), IProvinceRepository
{
    public async Task<IEnumerable<Province>> GetProvincesByRegionAsync(int regionId)
    {
        return await _context.Provinces
            .Where(p => p.RegionId == regionId)
            .ToListAsync();
    }

    public override async Task<Province> GetByIdAsync(int id)
    {
        return await _context.Provinces
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Province>> GetAllAsync()
    {
        return await _context.Provinces
                            .ToListAsync();
    }
}
