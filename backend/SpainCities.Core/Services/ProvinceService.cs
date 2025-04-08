using Core.Entities;
using Core.Interfases;

namespace Core.Services;

public class ProvinceService
{
    private readonly IProvinceRepository _provinceRepository;

    public ProvinceService(IProvinceRepository provinceRepository)
    {
        _provinceRepository = provinceRepository;
    }

    public async Task<Province> GetProvinceById(int id)
    {
        return await _provinceRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Province>> GetAllProvinces()
    {
        return await _provinceRepository.GetAllAsync();
    }
}
