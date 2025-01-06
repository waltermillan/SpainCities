using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class ImageRepository(SpainCitiesContext context) : GenericRepository<Image>(context), IImageRepository
{
    public override async Task<Image> GetByIdAsync(int id)
    {
        return await _context.Images
                          .FirstOrDefaultAsync(p => p.Id == id);

    }

    public override async Task<IEnumerable<Image>> GetAllAsync()
    {
        return await _context.Images
                            .ToListAsync();
    }

    public override async Task<(int totalRegistros, IEnumerable<Image> registros)> GetAllAsync(
                int pageIndex, int pageSize, string search)
    {
        var consulta = _context.Images as IQueryable<Image>;

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
