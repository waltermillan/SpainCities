namespace Core.Interfases;

public interface IUnitOfWork
{
    ICityRepository Cities { get; }
    IProvinceRepository Provinces { get; }
    IRegionRepository Regions { get; }
    IPictureRepository Pictures { get; }

    void Dispose();
    Task<int> SaveAsync();
}
