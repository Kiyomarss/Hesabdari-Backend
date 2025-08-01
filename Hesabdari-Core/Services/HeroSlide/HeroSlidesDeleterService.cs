using Hesabdari_Core.ServiceContracts;
using Hesabdari_Core.ServiceContracts.Storage;
using ServiceContracts;
using RepositoryContracts;
using Microsoft.Extensions.Logging;

namespace Services
{
 public class HeroSlidesDeleterService : IHeroSlidesDeleterService
 {
  //private field
  private readonly IHeroSlidesRepository _heroSlidesRepository;
  private readonly IImageStorageService _imageStorageService;
  private readonly ILogger<HeroSlidesGetterService> _logger;

  //constructor
  public HeroSlidesDeleterService(
   IHeroSlidesRepository heroSlidesRepository, 
   IImageStorageService imageStorageService,
   ILogger<HeroSlidesGetterService> logger)
  {
   _heroSlidesRepository = heroSlidesRepository;
   _imageStorageService = imageStorageService;
   _logger = logger;
  }
  
  public async Task<bool> DeleteHeroSlide(int heroSlideId)
  {
   var heroSlide = await _heroSlidesRepository.FindHeroSlideById(heroSlideId);

   if (heroSlide == null)
    throw new KeyNotFoundException($"heroSlide with ID {heroSlideId} does not exist.");

   await _imageStorageService.DeleteOldImagesAsync(heroSlide.ImageDesktopWebpUrl, heroSlide.ImageDesktopJpgUrl, heroSlide.ImageMobileWebpUrl, heroSlide.ImageMobileJpgUrl);

   return await _heroSlidesRepository.DeleteHeroSlide(heroSlideId);
  }
 }
}
