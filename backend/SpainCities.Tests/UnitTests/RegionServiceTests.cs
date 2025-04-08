using Core.Entities;
using Core.Interfases;
using Core.Services;
using Moq;

namespace Tests.UnitTests
{
    public class RegionServiceTests
    {
        [Fact]
        public async Task GetRegionById_ReturnsRegion_WhenRegionExists()
        {
            //Arrange
            var mockRegionRepository = new Mock<IRegionRepository>();
            var region = new Region { Id = 7, Name = "Cataluña", Population = 7901963, Capital = "Barcelona", Surface = 32091 };
            mockRegionRepository.Setup(repo => repo.GetByIdAsync(7)).ReturnsAsync(region);

            var regionService = new RegionService(mockRegionRepository.Object);

            //Act
            var result = await regionService.GetRegionById(7);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(7, result.Id);
            Assert.Equal("Cataluña", result.Name);
            Assert.Equal(7901963, result.Population);
            Assert.Equal("Barcelona", result.Capital);
            Assert.Equal(32091, result.Surface);
        }

        [Fact]
        public async Task GetAllRegions_ReturnsRegions_WhenRegionsExist()
        {
            //Arrange
            var mockRegionRepository = new Mock<IRegionRepository>();
            var regions = new List<Region>
            {
                new Region { Id = 7, Name = "Cataluña" },
                new Region { Id = 8, Name = "Madrid" }
            };
            mockRegionRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(regions);

            var regionService = new RegionService(mockRegionRepository.Object);

            //Act
            var result = await regionService.GetAllRegions();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, r => r.Name == "Cataluña");
            Assert.Contains(result, r => r.Name == "Madrid");
        }
    }
}
