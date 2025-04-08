using Core.Entities;

namespace Core.Interfases;

public interface IRegionRepository : IGenericRepository<Region>
{
    Task<Region> GetByRegionIdAsync(int regionId);
}
