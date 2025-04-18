﻿using Core.Entities;
using Core.Interfases;

namespace Core.Services;

public class PictureService
{
    private readonly IPictureRepository _pictureRepository;

    public PictureService(IPictureRepository pictureRepository)
    {
        _pictureRepository = pictureRepository;
    }

    public async Task<Picture> GetPictureById(int id)
    {
        return await _pictureRepository.GetByIdAsync(id);
    }
    public async Task<IEnumerable<Picture>> GetAllPictures()
    {
        return await _pictureRepository.GetAllAsync();
    }
}
