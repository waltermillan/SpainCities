using Core.Entities;
using Core.Interfases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services;

public class CityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<City> GetCityById(int id)
    {
        return await _cityRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<City>> GetCitiesByRegion(int regionId)
    {
        return await _cityRepository.GetCitiesByRegionIdAsync(regionId);
    }
}
