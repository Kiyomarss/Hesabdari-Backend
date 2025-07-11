using ServiceContracts;
using ContactsManager.Core.DTO;
using Hesabdari_Core.DTO;
using Hesabdari_Core.Utils;
using RepositoryContracts;
using Microsoft.Extensions.Logging;
using Serilog;

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

   return new GetHeroSlidesByIdResult(heroSlide.Id, heroSlide.Title, heroSlide.ImageUrl, heroSlide.Order, heroSlide.IsActive, heroSlide.StartDate.ToPersianDateTime(), heroSlide.EndDate.ToPersianDateTime());
  }

  public virtual async Task<List<GetHeroSlidesResult>> GetHeroSlides()
  {
   var heroSlides = await _heroSlidesRepository.GetHeroSlides();

   return heroSlides.Select(x => new GetHeroSlidesResult(x.Id, x.Title, x.ImageUrl, x.Order, x.IsActive, x.StartDate.ToPersianDateTime(), x.EndDate.ToPersianDateTime())).ToList();
  }
  
  public virtual async Task<ImagesResponse> GetHeroSlidesImageUrl()
  {
   var images = await _heroSlidesRepository.GetHeroSlidesImageUrl();

   return new ImagesResponse(images);
  }
 }
}
