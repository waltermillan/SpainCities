using Core.Entities;
using Core.Interfases;
using Core.Services;
using Moq;
using System.Collections.Generic;
using System.Linq; // Para usar Count()
using System.Threading.Tasks;
using Xunit;

namespace Tests.UnitTests;

public class ProvinceServiceTests
{
    [Fact]
    public async Task GetProvinceById_ReturnsProvince_WhenProvinceExists()
    {
        // Arrange
        var mockProvinceRepository = new Mock<IProvinceRepository>();
        var province = new Province { Id = 9, Name = "Barcelona", RegionId = 7 };
        mockProvinceRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(province);

        var provinceService = new ProvinceService(mockProvinceRepository.Object);

        // Act
        var result = await provinceService.GetProvinceById(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Barcelona", result.Name);
        Assert.Equal(9, result.Id);
        Assert.Equal(7, result.RegionId);
    }

    [Fact]
    public async Task GetAllProvinces_ReturnsProvinces_WhenProvincesExist()
    {
        // Arrange
        var mockProvinceRepository = new Mock<IProvinceRepository>();
        var provinces = new List<Province>
        {
            new Province { Id = 9, Name = "Barcelona" },
            new Province { Id = 13, Name = "Madrid" }
        };
        mockProvinceRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(provinces);

        var provinceService = new ProvinceService(mockProvinceRepository.Object);

        // Act
        var result = await provinceService.GetAllProvinces();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count()); // Usamos Count() para contar los elementos
        Assert.Contains(result, p => p.Name == "Barcelona");
        Assert.Contains(result, p => p.Name == "Madrid");
    }
}
