using AutoMapper;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("api/cities")] // Usamos el plural en la ruta para seguir la convención RESTful
public class CityController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CityController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<City>>> Get()
    {
        var cities = await _unitOfWork.Cities.GetAllAsync();
        return _mapper.Map<List<City>>(cities);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<City>> Get(int id)
    {
        var city = await _unitOfWork.Cities.GetByIdAsync(id);

        if (city is null)
            return NotFound();

        return _mapper.Map<City>(city);
    }

    [HttpGet("region/{regionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<City>>> GetCitiesByRegion(int regionId)
    {
        var cities = await _unitOfWork.Cities.GetCitiesByRegionIdAsync(regionId);

        if (cities is null || !cities.Any())
            return NotFound();

        return _mapper.Map<List<City>>(cities);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<City>> Post(City oCity)
    {
        var city = _mapper.Map<City>(oCity);
        _unitOfWork.Cities.Add(city);
        await _unitOfWork.SaveAsync();

        if (city is null)
            return BadRequest();

        oCity.Id = city.Id;
        return CreatedAtAction(nameof(Post), new { id = oCity.Id }, oCity);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<City>> Put([FromBody] City oCity)
    {
        if (oCity is null)
            return NotFound();

        var city = _mapper.Map<City>(oCity);
        _unitOfWork.Cities.Update(city);
        await _unitOfWork.SaveAsync();
        return oCity;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var city = await _unitOfWork.Cities.GetByIdAsync(id);

        if (city is null)
            return NotFound();

        _unitOfWork.Cities.Remove(city);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}