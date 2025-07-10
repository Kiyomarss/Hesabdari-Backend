using AutoFixture;
using Entities;
using FluentAssertions;
using Hesabdari_Core.Domain.Entities;
using Hesabdari_Core.DTO;
using Hesabdari_Core.ServiceContracts;
using Microsoft.Extensions.Logging;
using Moq;
using RepositoryContracts;
using Services;

namespace Hesabdari_ServiceTests
{
    public class HeroSlidesGetterServiceTests
    {
        private readonly Mock<IHeroSlidesRepository> _mockRepository;
        private readonly Mock<ILogger<HeroSlidesGetterService>> _mockHeroSlidesGetterServiceLogger;
        private readonly HeroSlidesGetterService _heroSlidesGetterService;
        private readonly Fixture _fixture;

        public HeroSlidesGetterServiceTests()
        {
            _mockRepository = new Mock<IHeroSlidesRepository>();
            _mockHeroSlidesGetterServiceLogger = new Mock<ILogger<HeroSlidesGetterService>>();
            _heroSlidesGetterService = new HeroSlidesGetterService(_mockRepository.Object, _mockHeroSlidesGetterServiceLogger.Object);
            _fixture = new Fixture();
        }
        
        
        [Fact]
        public async Task GetHeroSlides_ShouldReturnListOfHeroSlideResponses_WhenHeroSlidesExist()
        {
            // Arrange
            var heroSlides = _fixture.CreateMany<HeroSlide>(3).ToList();
            var expectedResponses = heroSlides.Select(c => c.ToHeroSlideResponse()).ToList();

            _mockRepository.Setup(repo => repo.GetHeroSlides()).ReturnsAsync(heroSlides);

            // Act
            var result = await _heroSlidesGetterService.GetHeroSlides();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<HeroSlideResponse>>(); 
            result.Should().HaveCount(heroSlides.Count);
            result.Should().BeEquivalentTo(expectedResponses);

            _mockRepository.Verify(repo => repo.GetHeroSlides(), Times.Once);
        }

        [Fact]
        public async Task GetHeroSlides_ShouldReturnEmptyList_WhenNoHeroSlidesExist()
        {
            // Arrange
            var heroSlides = new List<HeroSlide>();
            _mockRepository.Setup(repo => repo.GetHeroSlides()).ReturnsAsync(heroSlides);

            // Act
            var result = await _heroSlidesGetterService.GetHeroSlides();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<HeroSlideResponse>>();

            _mockRepository.Verify(repo => repo.GetHeroSlides(), Times.Once);
        }

        [Fact]
        public async Task FindHeroSlideById_ShouldReturnHeroSlide_WhenHeroSlideExists()
        {
            // Arrange
            var heroSlideId = Guid.NewGuid();
            var heroSlide = _fixture.Build<HeroSlide>()
                .With(b => b.Id, heroSlideId)
                .Create();

            _mockRepository.Setup(repo => repo.FindHeroSlideById(heroSlideId))
                .ReturnsAsync(heroSlide);

            // Act
            var result = await _heroSlidesGetterService.GetHeroSlideByHeroSlideId(heroSlideId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(heroSlide, options => options.ExcludingMissingMembers());

            _mockRepository.Verify(repo => repo.FindHeroSlideById(heroSlideId), Times.Once);
        }

        [Fact]
        public async Task FindHeroSlideById_ShouldReturnNull_WhenHeroSlideDoesNotExist()
        {
            // Arrange
            var heroSlideId = Guid.NewGuid();

            _mockRepository.Setup(repo => repo.FindHeroSlideById(heroSlideId))
                .ReturnsAsync((HeroSlide?)null);

            // Act
            var result = await _heroSlidesGetterService.GetHeroSlideByHeroSlideId(heroSlideId);

            // Assert
            result.Should().BeNull();

            _mockRepository.Verify(repo => repo.FindHeroSlideById(heroSlideId), Times.Once);
        }
    }
}