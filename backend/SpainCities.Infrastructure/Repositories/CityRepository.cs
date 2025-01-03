using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class CityRepository : GenericRepository<City>, ICityRepository
{
    public CityRepository(SpainCitiesCotext context) : base(context)
    {
    }

    // Método existente
    public override async Task<City> GetByIdAsync(int id)
    {
        return await _context.Cities
                          .FirstOrDefaultAsync(p => p.Id == id); // Cambié 'ProvinceId' por 'Id' para obtener la ciudad por ID
    }

    // Método existente
    public override async Task<IEnumerable<City>> GetAllAsync()
    {
        return await _context.Cities.ToListAsync();
    }

    // Método para obtener ciudades por RegionId
    public async Task<IEnumerable<City>> GetCitiesByRegionIdAsync(int regionId)
    {
        return await _context.Cities
                             .Where(c => c.RegionId == regionId)
                             .ToListAsync();
    }

    // Método existente para paginación y búsqueda
    public override async Task<(int totalRegistros, IEnumerable<City> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.Cities as IQueryable<City>;

        if (!String.IsNullOrEmpty(search))
        {
            consulta = consulta.Where(p => p.Name.ToLower().Contains(search.ToLower())); // Cambié 'Id' por 'Name' para buscar por nombre
        }

        var totalRegistros = await consulta.CountAsync();
        var registros = await consulta
                            .Skip((pageIndex - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

        return (totalRegistros, registros);
    }
}
