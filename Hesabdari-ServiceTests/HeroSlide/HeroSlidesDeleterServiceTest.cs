using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using RepositoryContracts;
using Services;
using Entities;
using HeroSlide_Core.ServiceContracts;

namespace HeroSlide_ServiceTests
{
    public class HeroSlidesDeleterServiceTests
    {
        private readonly Mock<IHeroSlidesRepository> _mockRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<ILogger<HeroSlidesGetterService>> _mockLogger;
        private readonly HeroSlidesDeleterService _heroSlidesDeleterService;
        private readonly Fixture _fixture;

        public HeroSlidesDeleterServiceTests()
        {
            _mockRepository = new Mock<IHeroSlidesRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<HeroSlidesGetterService>>();
            _heroSlidesDeleterService = new HeroSlidesDeleterService(_mockRepository.Object, _mockUnitOfWork.Object, _mockLogger.Object);
            _fixture = new Fixture();
        }

        [Fact]
        public async Task DeleteHeroSlide_ShouldReturnTrue_WhenHeroSlideExistsAndDeletedSuccessfully()
        {
            // Arrange
            var hesabdariId = Guid.NewGuid();
            var hesabdari = _fixture.Build<HeroSlide>().With(b => b.Id, hesabdariId).Create();

            _mockRepository.Setup(repo => repo.FindHeroSlideById(hesabdariId)).ReturnsAsync(hesabdari);
            _mockUnitOfWork.Setup(uow => uow.ExecuteTransactionAsync(It.IsAny<Func<Task<bool>>>()))
                           .Returns<Func<Task<bool>>>(op => op());
            _mockRepository.Setup(repo => repo.DeleteHeroSlide(hesabdariId)).ReturnsAsync(true);

            // Act
            var result = await _heroSlidesDeleterService.DeleteHeroSlide(hesabdariId);

            // Assert
            result.Should().BeTrue();
            _mockRepository.Verify(repo => repo.FindHeroSlideById(hesabdariId), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.ExecuteTransactionAsync(It.IsAny<Func<Task<bool>>>()), Times.Once);
            _mockRepository.Verify(repo => repo.DeleteHeroSlide(hesabdariId), Times.Once);
        }

        [Fact]
        public async Task DeleteHeroSlide_ShouldThrowKeyNotFoundException_WhenHeroSlideDoesNotExist()
        {
            // Arrange
            var hesabdariId = Guid.NewGuid();
            _mockRepository.Setup(repo => repo.FindHeroSlideById(hesabdariId)).ReturnsAsync((HeroSlide?)null);

            // Act
            Func<Task> act = async () => await _heroSlidesDeleterService.DeleteHeroSlide(hesabdariId);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>().WithMessage($"HeroSlide with ID {hesabdariId} does not exist.");
            _mockRepository.Verify(repo => repo.FindHeroSlideById(hesabdariId), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.ExecuteTransactionAsync(It.IsAny<Func<Task<bool>>>()), Times.Never);
            _mockRepository.Verify(repo => repo.DeleteHeroSlide(hesabdariId), Times.Never);
        }

        [Fact]
        public async Task DeleteHeroSlide_ShouldThrowException_WhenDeletionFails()
        {
            // Arrange
            var hesabdariId = Guid.NewGuid();
            var hesabdari = _fixture.Build<HeroSlide>().With(b => b.Id, hesabdariId).Create();

            _mockRepository.Setup(repo => repo.FindHeroSlideById(hesabdariId)).ReturnsAsync(hesabdari);
            _mockUnitOfWork.Setup(uow => uow.ExecuteTransactionAsync(It.IsAny<Func<Task<bool>>>()))
                           .ThrowsAsync(new Exception("Deletion failed"));

            // Act
            Func<Task> act = async () => await _heroSlidesDeleterService.DeleteHeroSlide(hesabdariId);

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage("Deletion failed");
            _mockRepository.Verify(repo => repo.FindHeroSlideById(hesabdariId), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.ExecuteTransactionAsync(It.IsAny<Func<Task<bool>>>()), Times.Once);
        }
    }
}