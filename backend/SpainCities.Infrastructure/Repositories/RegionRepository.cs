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

    public override async Task<(int totalRegistros, IEnumerable<Region> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.Regions as IQueryable<Region>;

        if (!String.IsNullOrEmpty(search))
        {
            consulta = consulta.Where(p => p.Id.ToString().Contains(search, StringComparison.CurrentCultureIgnoreCase));
        }


        var totalRegistros = await consulta
                                    .CountAsync();

        var registros = await consulta
                                .Include(u => u.Name)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }


}
