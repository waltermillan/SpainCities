using Core.Entities;

namespace Core.Interfases;

public interface IPictureRepository : IGenericRepository<Picture>
{
    Task<List<Picture>> GetAllAsync();
    Task<List<Picture>> FindAsync(System.Linq.Expressions.Expression<Func<Picture, bool>> predicate);
    Task<Picture> GetByIdAsync(int id);
}
