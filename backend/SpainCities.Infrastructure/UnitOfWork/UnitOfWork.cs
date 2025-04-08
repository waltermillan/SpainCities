using Core.Interfases;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly SpainCitiesContext _context;
    private ICityRepository _cities;
    private IProvinceRepository _provinces;
    private IRegionRepository _regions;
    private IPictureRepository _pictures;

    public UnitOfWork(SpainCitiesContext context)
    {
        _context = context;
    }

    public ICityRepository Cities
    {
        get
        {
            if (_cities is null)
                _cities = new CityRepository(_context);
            return _cities;
        }
    }

    public IProvinceRepository Provinces
    {
        get
        {
            if (_provinces is null)
                _provinces = new ProvinceRepository(_context);
            return _provinces;
        }
    }

    public IRegionRepository Regions
    {
        get
        {
            if (_regions is null)
                _regions = new RegionRepository(_context);
            return _regions;
        }
    }
    public IPictureRepository Pictures
    {
        get
        {
            if (_pictures is null)
                _pictures = new PictureRepository(_context);
            return _pictures;
        }
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
