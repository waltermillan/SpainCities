using Core.Entities;
using Core.Interfaces;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class RegionRepository : GenericRepository<Region>, IRegionRepository
{
    public RegionRepository(SpainCitiesCotext context) : base(context)
    {
    }

    public override async Task<Region> GetByIdAsync(int id)
    {
        return await _context.Regions
                          //.Include(p => p.FechaAlquiler)
                          //.Include(p => p.FechaDevolucion)
                          .FirstOrDefaultAsync(p => p.Id == id);

    }

    public override async Task<IEnumerable<Region>> GetAllAsync()
    {
        return await _context.Regions
                            //.Include(u => u.FechaAlquiler)
                            //.Include(u => u.FechaDevolucion)
                            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Region> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.Regions as IQueryable<Region>;

        if (!String.IsNullOrEmpty(search))
        {
            consulta = consulta.Where(p => p.Id.ToString().ToLower().Contains(search));
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
