using Core.Entities;
using Core.Interfaces;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProvinceRepository : GenericRepository<Province>, IProvinceRepository
{
    public ProvinceRepository(SpainCitiesCotext context) : base(context)
    {
    }

    // Método para obtener provincias por regionId
    public async Task<IEnumerable<Province>> GetProvincesByRegionAsync(int regionId)
    {
        return await _context.Provinces
            .Where(p => p.RegionId == regionId)
            .ToListAsync();
    }

    // Método para obtener una provincia por id (Método existente)
    public override async Task<Province> GetByIdAsync(int id)
    {
        return await _context.Provinces
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    // Método para obtener todas las provincias (Método existente)
    public override async Task<IEnumerable<Province>> GetAllAsync()
    {
        return await _context.Provinces
                            .ToListAsync();
    }
}
