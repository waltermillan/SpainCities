using Core.Entities;
using Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/[controller]")]
public class RegionController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Region>>> Get()
    {
        var region = await _unitOfWork.Regions
                                    .GetAllAsync();

        return _mapper.Map<List<Region>>(region);
    }

    [HttpGet("Get")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Region>> Get(int id)
    {
        var region = await _unitOfWork.Regions.GetByIdAsync(id);
        if (region == null)
            return NotFound();

        return _mapper.Map<Region>(region);
    }

    //POST: api/Region
    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Post(Region oRegion)
    {
        var region = _mapper.Map<Region>(oRegion);
        _unitOfWork.Regions.Add(region);
        await _unitOfWork.SaveAsync();
        if (region == null)
        {
            return BadRequest();
        }
        oRegion.Id = region.Id;
        return CreatedAtAction(nameof(Post), new { id = oRegion.Id }, oRegion);
    }


    //PUT: api/Regions/4
    [HttpPut("Update/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Put(int id, [FromBody] Region oRegion)
    {
        if (oRegion == null)
            return NotFound();

        var region = _mapper.Map<Region>(oRegion);
        _unitOfWork.Regions.Update(region);
        await _unitOfWork.SaveAsync();
        return oRegion;
    }

    //DELETE: api/Regions
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var region = await _unitOfWork.Regions.GetByIdAsync(id);
        if (region == null)
            return NotFound();

        _unitOfWork.Regions.Remove(region);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }


}
