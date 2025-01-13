using Core.Entities;
using Core.Interfases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services;

public class RegionService
{
    private readonly IRegionRepository _regionRepository;

    public RegionService(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }

    public async Task<Region> GetRegionById(int id)
    {
        return await _regionRepository.GetByIdAsync(id);
    }
    public async Task<IEnumerable<Region>> GetAllRegions()
    {
        return await _regionRepository.GetAllAsync();
    }
}
