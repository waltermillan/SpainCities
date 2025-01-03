using Core.Entities;
using Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/[controller]")]
public class ImageController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ImageController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Image>>> Get()
    {
        var image = await _unitOfWork.Images
                                    .GetAllAsync();

        return _mapper.Map<List<Image>>(image);
    }

    [HttpGet("Get")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Image>> Get(int id)
    {
        var image = await _unitOfWork.Images.GetByIdAsync(id);
        if (image == null)
            return NotFound();

        return _mapper.Map<Image>(image);
    }

    //POST: api/Image
    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Image>> Post(Image oImage)
    {
        var image = _mapper.Map<Image>(oImage);
        _unitOfWork.Images.Add(image);
        await _unitOfWork.SaveAsync();
        if (image == null)
        {
            return BadRequest();
        }
        oImage.Id = image.Id;
        return CreatedAtAction(nameof(Post), new { id = oImage.Id }, oImage);
    }


    //PUT: api/Images/4
    [HttpPut("Update/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Image>> Put(int id, [FromBody] Image oImage)
    {
        if (oImage == null)
            return NotFound();

        var image = _mapper.Map<Image>(oImage);
        _unitOfWork.Images.Update(image);
        await _unitOfWork.SaveAsync();
        return oImage;
    }

    //DELETE: api/Images
    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var image = await _unitOfWork.Images.GetByIdAsync(id);
        if (image == null)
            return NotFound();

        _unitOfWork.Images.Remove(image);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }


}
