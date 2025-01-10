using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class PictureRepository(SpainCitiesContext context) : GenericRepository<Picture>(context), IPictureRepository
{
    public override async Task<Picture> GetByIdAsync(int id)
    {
        return await _context.Pictures
                          .FirstOrDefaultAsync(p => p.Id == id);

    }

    public override async Task<IEnumerable<Picture>> GetAllAsync()
    {
        return await _context.Pictures
                            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Picture> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.Pictures as IQueryable<Picture>;

        if (!String.IsNullOrEmpty(search))
        {
            consulta = consulta.Where(p => p.Id.ToString().Contains(search, StringComparison.CurrentCultureIgnoreCase));
        }


        var totalRegistros = await consulta
                                    .CountAsync();

        var registros = await consulta
                                .Include(u => u.ImageBase64)
                                .Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return (totalRegistros, registros);
    }


}
