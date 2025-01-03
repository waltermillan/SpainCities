using Core.Interfases;

namespace Core.Interfaces;

public interface IUnitOfWork
{
    ICityRepository Cities { get; }
    IProvinceRepository Provinces { get; }
    IRegionRepository Regions { get; }
    IImageRepository Images { get; }
    Task<int> SaveAsync();
}
