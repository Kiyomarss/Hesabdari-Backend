using ServiceContracts;
using ContactsManager.Core.DTO;
using Hesabdari_Core.DTO;
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
  
  public virtual async Task<HeroSlideResponse?> GetHeroSlideByHeroSlideId(int heroSlideId)
  {
   var heroSlide = await _heroSlidesRepository.FindHeroSlideById(heroSlideId);

   return heroSlide?.ToHeroSlideResponse();
  }
  
  public virtual async Task<List<HeroSlideResponse>> GetHeroSlides()
  {
   var heroSlides = await _heroSlidesRepository.GetHeroSlides();

   return heroSlides.Select(heroSlide => heroSlide.ToHeroSlideResponse()).ToList();
  }
 }
}
