using AutoMapper;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CityController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CityController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // Método existente: obtener todas las ciudades
    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<City>>> Get()
    {
        var cities = await _unitOfWork.Cities.GetAllAsync();
        return _mapper.Map<List<City>>(cities);
    }

    // Método existente: obtener una ciudad por su ID
    [HttpGet("Get")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<City>> Get(int id)
    {
        var city = await _unitOfWork.Cities.GetByIdAsync(id);
        if (city == null)
            return NotFound();

        return _mapper.Map<City>(city);
    }

    // Nuevo método: obtener ciudades por RegionId
    [HttpGet("GetByRegion/{regionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<City>>> GetCitiesByRegion(int regionId)
    {
        // Obtener ciudades por RegionId
        var cities = await _unitOfWork.Cities.GetCitiesByRegionIdAsync(regionId);

        if (cities == null || !cities.Any())
        {
            return NotFound();  // Si no hay ciudades para esa región, devolver un 404
        }

        return _mapper.Map<List<City>>(cities);
    }

    // Método existente: agregar una ciudad
    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<City>> Post(City oCity)
    {
        var city = _mapper.Map<City>(oCity);
        _unitOfWork.Cities.Add(city);
        await _unitOfWork.SaveAsync();
        if (city == null)
        {
            return BadRequest();
        }
        oCity.Id = city.Id;
        return CreatedAtAction(nameof(Post), new { id = oCity.Id }, oCity);
    }

    // Método existente: actualizar una ciudad
    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<City>> Put([FromBody] City oCity)
    {
        if (oCity == null)
            return NotFound();

        var city = _mapper.Map<City>(oCity);
        _unitOfWork.Cities.Update(city);
        await _unitOfWork.SaveAsync();
        return oCity;
    }

    // Método existente: eliminar una ciudad
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var city = await _unitOfWork.Cities.GetByIdAsync(id);
        if (city == null)
            return NotFound();

        _unitOfWork.Cities.Remove(city);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}