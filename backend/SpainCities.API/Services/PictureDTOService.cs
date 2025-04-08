using API.DTOs;
using Core.Interfases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class PictureDTOService
    {
        private readonly IUnitOfWork _context;

        public PictureDTOService(IUnitOfWork context)
        {
            _context = context;
        }

        public async Task<List<PictureDTO>> GetPicturesByRegionAsync(int regionId)
        {
            var pictures = await _context.Pictures.FindAsync(p => p.RegionId == regionId);

            var pictureDTOs = pictures.Select(p => new PictureDTO
            {
                Id = p.Id,
                IdRegion = p.RegionId,
                ImageBase64 = p.ImageBase64,
                RegionName = p.Name
            }).ToList();

            return pictureDTOs;
        }
    }
}
