using ServiceContracts;
using Hesabdari_Core.DTO;
using Hesabdari_Core.Utils;
using RepositoryContracts;
using Microsoft.Extensions.Logging;

namespace Services
{
 public class HeroSlidesGetterService : IHeroSlidesGetterService
 {
  //private field
  private readonly IHeroSlidesRepository _heroSlidesRepository;
  private readonly ILogger<HeroSlidesGetterService> _logger;

  public HeroSlidesGetterService(IHeroSlidesRepository heroSlidesRepository, ILogger<HeroSlidesGetterService> logger)
  {
   _heroSlidesRepository = heroSlidesRepository;
   _logger = logger;
  }
  
  public virtual async Task<GetHeroSlidesByIdResult> GetHeroSlideById(int heroSlideId)
  {
   var heroSlide = await _heroSlidesRepository.FindHeroSlideById(heroSlideId);

   if (heroSlide == null)
    throw new KeyNotFoundException($"HeroSlide with ID {heroSlideId} does not exist.");

   return new GetHeroSlidesByIdResult(heroSlide.Id, heroSlide.Title, heroSlide.ImageMobileJpgUrl, heroSlide.Order, heroSlide.IsActive, heroSlide.StartDate.ToPersianDate(), heroSlide.EndDate.ToPersianDate());
  }

  public virtual async Task<List<GetHeroSlidesResult>> GetHeroSlides()
  {
   var heroSlides = await _heroSlidesRepository.GetHeroSlides();

   return heroSlides.Select(x => new GetHeroSlidesResult(x.Id, x.Title, x.ImageMobileJpgUrl, x.Order, x.IsActive, x.StartDate.ToPersianDate(), x.EndDate.ToPersianDate())).ToList();
  }
  
  public virtual async Task<ImagesResponse> GetHeroSlidesImageUrl()
  {
   var images = await _heroSlidesRepository.GetHeroSlidesImageUrl();
   return new ImagesResponse(images);
  }
 }
}
