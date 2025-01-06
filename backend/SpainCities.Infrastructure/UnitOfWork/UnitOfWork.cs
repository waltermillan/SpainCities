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
    private IImageRepository _images;

    public UnitOfWork(SpainCitiesContext context)
    {
        _context = context;
    }

    public ICityRepository Cities
    {
        get
        {
            if (_cities == null)
            {
                _cities = new CityRepository(_context);
            }
            return _cities;
        }
    }

    public IProvinceRepository Provinces
    {
        get
        {
            if (_provinces == null)
            {
                _provinces = new ProvinceRepository(_context);
            }
            return _provinces;
        }
    }

    public IRegionRepository Regions
    {
        get
        {
            if (_regions == null)
            {
                _regions = new RegionRepository(_context);
            }
            return _regions;
        }
    }
    public IImageRepository Images
    {
        get
        {
            if (_images == null)
            {
                _images = new ImageRepository(_context);
            }
            return _images;
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
