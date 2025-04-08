using Core.Entities;
using Core.Interfases;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers;
public class ProvincesController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProvincesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet("region/{regionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> GetAllByRegion(int regionId)
    {
        var provinces = await _unitOfWork.Provinces.GetProvincesByRegionAsync(regionId);

        if (provinces is null || !provinces.Any())
            return NotFound(new { Message = "No provinces found for this region" });

        var region = await _unitOfWork.Regions.GetByIdAsync(regionId);

        if (region is null)
            return NotFound(new { Message = "Region not found" });

        var result = new
        {
            regionId = region.Id,
            regionName = region.Name,
            provinces = provinces.Select(p => new { p.Id, p.Name }).ToList()
        };

        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Province>> Get(int id)
    {
        var province = await _unitOfWork.Provinces.GetByIdAsync(id);

        if (province is null)
            return NotFound();

        return _mapper.Map<Province>(province);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Province>> Post(Province oProvince)
    {
        var province = _mapper.Map<Province>(oProvince);
        _unitOfWork.Provinces.Add(province);
        await _unitOfWork.SaveAsync();

        if (province is null)
            return BadRequest();

        oProvince.Id = province.Id;
        return CreatedAtAction(nameof(Post), new { id = oProvince.Id }, oProvince);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Province>> Put([FromBody] Province oProvince)
    {
        if (oProvince is null)
            return NotFound();

        var province = _mapper.Map<Province>(oProvince);
        _unitOfWork.Provinces.Update(province);
        await _unitOfWork.SaveAsync();

        return oProvince;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var provinces = await _unitOfWork.Provinces.GetByIdAsync(id);

        if (provinces is null)
            return NotFound();

        _unitOfWork.Provinces.Remove(provinces);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
