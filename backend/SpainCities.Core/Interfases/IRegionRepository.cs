using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfases
{
    public interface IRegionRepository : IGenericRepository<Region>
    {
        Task<Region> GetByRegionIdAsync(int regionId);
    }
}
