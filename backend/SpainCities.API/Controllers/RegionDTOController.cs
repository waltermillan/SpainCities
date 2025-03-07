using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/regionsDTO")]
    [ApiController]
    public class RegionDTOController : ControllerBase
    {
        private readonly RegionDTOService _regionDTOService;

        public RegionDTOController(RegionDTOService regionDTOService)
        {
            _regionDTOService = regionDTOService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegionDTO(int id)
        {
            var customerDTO = await _regionDTOService.GetRegionDTOAsync(id);

            if (customerDTO is null)
                return NotFound(); // o algún otro manejo de error

            return Ok(customerDTO);
        }
    }
}
