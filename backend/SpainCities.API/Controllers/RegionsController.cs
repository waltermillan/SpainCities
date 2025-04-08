using Core.Entities;
using Core.Interfases;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Controllers;

public class RegionsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly RegionDTOService _regionDTOService;

    public RegionsController(IUnitOfWork unitOfWork, IMapper mapper, RegionDTOService regionDTOService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _regionDTOService = regionDTOService;   
    }

    [HttpGet("cities/{cityId}")]
    public async Task<IActionResult> GetRegionDTO(int cityId)
    {
        var customerDTO = await _regionDTOService.GetRegionDTOAsync(cityId);

        if (customerDTO is null)
            return NotFound();

        return Ok(customerDTO);
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Region>>> Get()
    {
        var region = await _unitOfWork.Regions.GetAllAsync();
        return _mapper.Map<List<Region>>(region);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Region>> Get(int id)
    {
        var region = await _unitOfWork.Regions.GetByIdAsync(id);

        if (region is null)
            return NotFound();

        return _mapper.Map<Region>(region);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Post(Region oRegion)
    {
        var region = _mapper.Map<Region>(oRegion);
        _unitOfWork.Regions.Add(region);
        await _unitOfWork.SaveAsync();

        if (region is null)
            return BadRequest();

        oRegion.Id = region.Id;
        return CreatedAtAction(nameof(Post), new { id = oRegion.Id }, oRegion);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Put([FromBody] Region oRegion)
    {
        if (oRegion is null)
            return NotFound();

        var region = _mapper.Map<Region>(oRegion);
        _unitOfWork.Regions.Update(region);
        await _unitOfWork.SaveAsync();
        return oRegion;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var region = await _unitOfWork.Regions.GetByIdAsync(id);

        if (region is null)
            return NotFound();

        _unitOfWork.Regions.Remove(region);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }


}
