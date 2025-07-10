using Hesabdari_Core.ServiceContracts;
using ServiceContracts;
using RepositoryContracts;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Services
{
 public class HeroSlidesDeleterService : IHeroSlidesDeleterService
 {
  //private field
  private readonly IHeroSlidesRepository _heroSlidesRepository;
  private readonly IUnitOfWork _unitOfWork;
  private readonly ILogger<HeroSlidesGetterService> _logger;

  //constructor
  public HeroSlidesDeleterService(IHeroSlidesRepository heroSlidesRepository, IUnitOfWork unitOfWork, ILogger<HeroSlidesGetterService> logger)
  {
   _heroSlidesRepository = heroSlidesRepository;
   _unitOfWork = unitOfWork;
   _logger = logger;
  }
  
  public async Task<bool> DeleteHeroSlide(Guid heroSlideId)
  {
   var heroSlide = await _heroSlidesRepository.FindHeroSlideById(heroSlideId);
   if (heroSlide == null)
    throw new KeyNotFoundException($"heroSlide with ID {heroSlideId} does not exist.");

   return await _unitOfWork.ExecuteTransactionAsync(async () => await _heroSlidesRepository.DeleteHeroSlide(heroSlideId));
  }
 }
}
