using Core.Entities;
using Core.Interfases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfases;

public interface IProvinceRepository : IGenericRepository<Province>
{
    Task<IEnumerable<Province>> GetProvincesByRegionAsync(int regionId);
}
