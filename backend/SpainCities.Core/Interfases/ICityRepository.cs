using Core.Entities;

namespace Core.Interfases;

public interface ICityRepository : IGenericRepository<City>
{
    Task<IEnumerable<City>> GetCitiesByRegionIdAsync(int regionId);
}
