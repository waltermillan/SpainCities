using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CityRepository(SpainCitiesContext context) : GenericRepository<City>(context), ICityRepository
{

    public override async Task<City> GetByIdAsync(int id)
    {
        return await _context.Cities
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<City>> GetAllAsync()
    {
        return await _context.Cities.ToListAsync();
    }

    public async Task<IEnumerable<City>> GetCitiesByRegionIdAsync(int regionId)
    {
        return await _context.Cities
                             .Where(c => c.RegionId == regionId)
                             .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<City> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.Cities as IQueryable<City>;

        if (!string.IsNullOrEmpty(search))
        {
            consulta = consulta.Where(p => p.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase));
        }

        var totalRegistros = await consulta.CountAsync();
        var registros = await consulta
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

        return (totalRegistros, registros);
    }
}