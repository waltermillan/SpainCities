using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class PictureRepository(SpainCitiesContext context) : GenericRepository<Picture>(context), IPictureRepository
{
    public async Task<List<Picture>> GetAllAsync()
    {
        return await _context.Pictures.ToListAsync();
    }

    public async Task<List<Picture>> FindAsync(System.Linq.Expressions.Expression<Func<Picture, bool>> predicate)
    {
        return await _context.Pictures.Where(predicate).ToListAsync();
    }

    public async Task<Picture> GetByIdAsync(int id)
    {
        return await _context.Pictures.FirstOrDefaultAsync(p => p.Id == id);
    }


}
