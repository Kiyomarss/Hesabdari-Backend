using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.Kernel;
using Entities;
using FluentAssertions;
using Hesabdari_Core.DTO;
using Hesabdari_Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using RepositoryContracts;
using Services;
using Xunit;

public class IFormFileSpecimen : ISpecimenBuilder
{
    public object Create(object request, ISpecimenContext context)
    {
        if (request is Type type && type == typeof(IFormFile))
        {
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(f => f.FileName).Returns("test.jpg");
            return fileMock.Object;
        }
        return new NoSpecimen();
    }
}

public class HeroSlidesUpdaterServiceTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IHeroSlidesRepository> _mockRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly HeroSlidesUpdaterService _heroSlidesUpdaterService;


    public HeroSlidesUpdaterServiceTests()
    {
        _fixture = new Fixture();
        _fixture.Customizations.Add(new IFormFileSpecimen());

        _mockRepository = new Mock<IHeroSlidesRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _heroSlidesUpdaterService = new HeroSlidesUpdaterService(_mockRepository.Object, _mockUnitOfWork.Object, Mock.Of<ILogger<HeroSlidesGetterService>>());
    }
    
    [Fact]
    public async Task UpdateHeroSlide_ShouldThrowArgumentNullException_WhenRequestIsNull()
    {
        // Act
        Func<Task> act = async () => await _heroSlidesUpdaterService.UpdateHeroSlide(null);

        // Assert
        await act.Should().ThrowAsync<ArgumentNullException>();
    }

    [Fact]
    public async Task UpdateHeroSlide_ShouldUpdateHeroSlide_WhenDataIsValid()
    {
        // Arrange
        var heroSlideRequest = _fixture.Create<HeroSlideUpsertRequest>();
        var updatedHeroSlide = _fixture.Create<HeroSlide>();
        var expectedResponse = updatedHeroSlide.ToHeroSlideResponse();

        _mockRepository.Setup(repo => repo.UpdateHeroSlide(heroSlideRequest)).ReturnsAsync(updatedHeroSlide);
        _mockUnitOfWork.Setup(uow => uow.ExecuteTransactionAsync(It.IsAny<Func<Task<HeroSlideResponse>>>()))
                       .Returns<Func<Task<HeroSlideResponse>>>(operation => operation());

        // Act
        var result = await _heroSlidesUpdaterService.UpdateHeroSlide(heroSlideRequest);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedResponse);
        _mockRepository.Verify(repo => repo.UpdateHeroSlide(heroSlideRequest), Times.Once);
        _mockUnitOfWork.Verify(uow => uow.ExecuteTransactionAsync(It.IsAny<Func<Task<HeroSlideResponse>>>()), Times.Once);
    }
}
