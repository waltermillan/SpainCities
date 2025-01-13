﻿using Core.Entities;
using Core.Interfases;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers;

[Route("api/[controller]")]
public class ProvinceController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProvinceController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // GET: api/Provinces/GetAllByRegion/{regionId} (Nuevo método)
    [HttpGet("GetAllByRegion/{regionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> GetAllByRegion(int regionId)
    {
        // Obtener las provincias por regionId
        var provinces = await _unitOfWork.Provinces.GetProvincesByRegionAsync(regionId);

        // Comprobar si existen provincias para esa región
        if (provinces == null || !provinces.Any())
        {
            return NotFound(new { Message = "No provinces found for this region" });
        }

        // Obtener el nombre de la región
        var region = await _unitOfWork.Regions.GetByIdAsync(regionId);
        if (region == null)
        {
            return NotFound(new { Message = "Region not found" });
        }

        // Construir el objeto de respuesta
        var result = new
        {
            regionId = region.Id,
            regionName = region.Name,
            provinces = provinces.Select(p => new { p.Id, p.Name }).ToList()
        };

        return Ok(result);
    }

    // GET: api/Provinces/Get (Método existente)
    [HttpGet("Get")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Province>> Get(int id)
    {
        var province = await _unitOfWork.Provinces.GetByIdAsync(id);
        if (province == null)
            return NotFound();

        return _mapper.Map<Province>(province);
    }

    // POST: api/Provinces/Add (Método existente)
    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Province>> Post(Province oProvince)
    {
        var province = _mapper.Map<Province>(oProvince);
        _unitOfWork.Provinces.Add(province);
        await _unitOfWork.SaveAsync();

        if (province == null)
        {
            return BadRequest();
        }

        oProvince.Id = province.Id;
        return CreatedAtAction(nameof(Post), new { id = oProvince.Id }, oProvince);
    }

    // PUT: api/Provinces/Update/{id} (Método existente)
    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Province>> Put([FromBody] Province oProvince)
    {
        if (oProvince == null)
            return NotFound();

        var province = _mapper.Map<Province>(oProvince);
        _unitOfWork.Provinces.Update(province);
        await _unitOfWork.SaveAsync();

        return oProvince;
    }

    // DELETE: api/Provinces/Delete/{id} (Método existente)
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var provinces = await _unitOfWork.Provinces.GetByIdAsync(id);
        if (provinces == null)
            return NotFound();

        _unitOfWork.Provinces.Remove(provinces);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}