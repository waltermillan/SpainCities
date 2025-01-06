using Core.Interfases;

namespace Core.Interfases;

public interface IUnitOfWork
{
    ICityRepository Cities { get; }
    IProvinceRepository Provinces { get; }
    IRegionRepository Regions { get; }
    IImageRepository Images { get; }

    void Dispose();
    Task<int> SaveAsync();
}
