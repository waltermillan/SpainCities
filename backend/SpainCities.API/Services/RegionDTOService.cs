using API.DTOs;
using Core.Interfases;

namespace API.Services;

public class RegionDTOService
{
    private readonly IRegionRepository _regionRepository;
    private readonly IProvinceRepository _provinceRepository;
    private readonly ICityRepository _cityRepository;

    public RegionDTOService(IRegionRepository regionRepository, 
                            IProvinceRepository provincesRepository,
                            ICityRepository cityRepository)
    {
        _regionRepository = regionRepository;
        _provinceRepository = provincesRepository;
        _cityRepository = cityRepository;
    }

    public async Task<RegionDTO> GetRegionDTOAsync(int cityId)
    {
        var city = await _cityRepository.GetByIdAsync(cityId);
        var province = await _provinceRepository.GetByIdAsync(city.ProvinceId);
        var region = await _regionRepository.GetByIdAsync(province.RegionId);


        if ( region is null || province is null || city is null )
            return null;

        var regionDTO = new RegionDTO
        {
            IdRegion = region.Id,
            RegionName = region.Name,

            IdProvince = province.Id,
            ProvinceName = province.Name,

            IdCity = cityId,
            CityName = city.Name
        };

        return regionDTO;
    }
}
