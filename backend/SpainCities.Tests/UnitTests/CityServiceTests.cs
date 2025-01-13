using Core.Entities;
using Core.Interfases;
using Core.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests;

public class CityServiceTests
{
    [Fact]
    public async Task GetCityById_ReturnsCity_WhenCityExists()
    {
        // Arrange
        var mockCityRepository = new Mock<ICityRepository>();
        var city = new City { Id = 1, Name = "Madrid", ProvinceId = 1, RegionId = 1 };
        mockCityRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(city);

        var cityService = new CityService(mockCityRepository.Object);

        // Act
        var result = await cityService.GetCityById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Madrid", result.Name);
        Assert.Equal(1, result.Id);
    }

    [Fact]
    public async Task GetCitiesByRegion_ReturnsCities_WhenCitiesExist()
    {
        // Arrange
        var mockCityRepository = new Mock<ICityRepository>();
        var cities = new List<City>
        {
            new City { Id = 61, Name = "Madrid", ProvinceId = 13, RegionId = 8 },
            new City { Id = 49, Name = "Barcelona", ProvinceId = 9, RegionId = 7 }
        };
        mockCityRepository.Setup(repo => repo.GetCitiesByRegionIdAsync(1)).ReturnsAsync(cities);

        var cityService = new CityService(mockCityRepository.Object);

        // Act
        var result = await cityService.GetCitiesByRegion(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count()); // Esperamos dos ciudades
        Assert.Contains(result, c => c.Name == "Madrid");
        Assert.Contains(result, c => c.Name == "Barcelona");
    }
}
