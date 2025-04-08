using Core.Entities;

namespace Core.Interfases;

public interface IProvinceRepository : IGenericRepository<Province>
{
    Task<IEnumerable<Province>> GetProvincesByRegionAsync(int regionId);
}
