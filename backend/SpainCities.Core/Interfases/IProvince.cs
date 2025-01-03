using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProvinceRepository : IGenericRepository<Province>
    {
        Task<IEnumerable<Province>> GetProvincesByRegionAsync(int regionId); // Añadir esta línea
    }
}
