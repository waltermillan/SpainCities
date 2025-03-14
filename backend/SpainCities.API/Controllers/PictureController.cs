﻿using Core.Entities;
using Core.Interfases;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("api/pictures")]
public class PictureController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PictureController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Picture>>> Get()
    {
        var picture = await _unitOfWork.Pictures
                                    .GetAllAsync();

        return _mapper.Map<List<Picture>>(picture);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Picture>> Get(int id)
    {
        var picture = await _unitOfWork.Pictures.GetByIdAsync(id);

        if (picture is null)
            return NotFound();

        return _mapper.Map<Picture>(picture);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Picture>> Post(Picture oPicture)
    {
        var picture = _mapper.Map<Picture>(oPicture);
        _unitOfWork.Pictures.Add(picture);
        await _unitOfWork.SaveAsync();

        if (picture is null)
            return BadRequest();

        oPicture.Id = picture.Id;
        return CreatedAtAction(nameof(Post), new { id = oPicture.Id }, oPicture);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Picture>> Put([FromBody] Picture oPicture)
    {
        if (oPicture is null)
            return NotFound();

        var picture = _mapper.Map<Picture>(oPicture);
        _unitOfWork.Pictures.Update(picture);
        await _unitOfWork.SaveAsync();
        return oPicture;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var picture = await _unitOfWork.Pictures.GetByIdAsync(id);

        if (picture is null)
            return NotFound();

        _unitOfWork.Pictures.Remove(picture);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }
}
